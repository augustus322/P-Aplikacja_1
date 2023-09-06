using PrzepisyV2.Commands;
using PrzepisyV2.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrzepisyV2.ViewModels
{
    public class RecipeViewViewModel : ViewModelBase
    {
        public RecipeListViewModel RecipeListViewModel { get; }
        public RecipeDetailsViewModel RecipeDetailsViewModel { get; }
        public ICommand AddRecipeCommand { get; }

        public RecipeViewViewModel(RecipeStore recipeStore, SelectedRecipeStore _selectedRecipeStore, ModalNavigationStore modalNavigationStore)
        {
            RecipeListViewModel = RecipeListViewModel.LoadViewModel(recipeStore, _selectedRecipeStore, modalNavigationStore);
            RecipeDetailsViewModel = new RecipeDetailsViewModel(_selectedRecipeStore);

            AddRecipeCommand = new OpenAddRecipeCommand(recipeStore, modalNavigationStore);
        }
    }
}
