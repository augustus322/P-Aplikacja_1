using PrzepisyV2.Commands;
using PrzepisyV2.Domain.Models;
using PrzepisyV2.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrzepisyV2.ViewModels
{
    public class RecipeListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<RecipeListItemViewModel> _recipeListItemViewModels;
        private readonly RecipeStore _recipeStore;
        private readonly SelectedRecipeStore _selectedRecipeStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        //private readonly ModalNavigationStore modalNavigationStore;

        public IEnumerable<RecipeListItemViewModel> RecipeListItemViewModels => _recipeListItemViewModels;

        private RecipeListItemViewModel _selectedRecipeItemViewModel;
        public RecipeListItemViewModel SelectedRecipeItemViewModel
        {
            get 
            { 
                return _selectedRecipeItemViewModel; 
            }
            set 
            { 
                _selectedRecipeItemViewModel = value; 
                OnPropertyChanged(nameof(SelectedRecipeItemViewModel));

                _selectedRecipeStore.SelectedRecipe = _selectedRecipeItemViewModel?.Recipe;
            }
        }

        public ICommand LoadRecipesCommand { get; }

        public RecipeListViewModel(RecipeStore recipeStore, SelectedRecipeStore selectedRecipeStore, ModalNavigationStore modalNavigationStore)
        {
            _recipeStore = recipeStore;
            _selectedRecipeStore = selectedRecipeStore;
            _modalNavigationStore = modalNavigationStore;
            _recipeListItemViewModels = new ObservableCollection<RecipeListItemViewModel>();

            LoadRecipesCommand = new LoadRecipesCommand(recipeStore);

            _recipeStore.RecipesLoaded += recipeStore_ReipesLoaded;
            _recipeStore.RecipeAdded += recipeStore_RecipeAdded;
            _recipeStore.RecipeUpdated += recipeStore_RecipeUpdated;
            _recipeStore.RecipeDeleted += recipeStore_RecipeDeleted;
        }

        private void recipeStore_RecipeDeleted(Guid id)
        {
            var itemViewModel = _recipeListItemViewModels.FirstOrDefault(y => y.Recipe?.Id == id);
            if(itemViewModel != null)
            {
                _recipeListItemViewModels.Remove(itemViewModel);
            }
        }

        private void recipeStore_ReipesLoaded()
        {
            _recipeListItemViewModels.Clear();

            foreach (Recipe recipe in _recipeStore.Recipes)
            {
                AddRecipe(recipe);
            }
        }

        protected override void Dispose()
        {
            _recipeStore.RecipesLoaded -= recipeStore_ReipesLoaded;
            _recipeStore.RecipeAdded -= recipeStore_RecipeAdded;
            _recipeStore.RecipeAdded -= recipeStore_RecipeUpdated;
            _recipeStore.RecipeDeleted -= recipeStore_RecipeDeleted;
            base.Dispose();
        }
        private void recipeStore_RecipeUpdated(Recipe recipe)
        {
            var recipeViewModel = _recipeListItemViewModels.FirstOrDefault(y => y.Recipe.Id == recipe.Id);

            if(recipeViewModel != null) 
            {
                recipeViewModel.Update(recipe);
            }
        }

        private void recipeStore_RecipeAdded(Recipe recipe)
        {
            AddRecipe(recipe);
        }

        private void AddRecipe(Recipe recipe)
        {
            _recipeListItemViewModels.Add(new RecipeListItemViewModel(recipe, _recipeStore, _modalNavigationStore));
        }

        public static RecipeListViewModel LoadViewModel(RecipeStore recipeStore, SelectedRecipeStore selectedRecipeStore, ModalNavigationStore modalNavigationStore)
        {
            RecipeListViewModel viewModel = new RecipeListViewModel(recipeStore, selectedRecipeStore, modalNavigationStore);

            viewModel.LoadRecipesCommand.Execute(null);

            return viewModel;
        }
    }
}
