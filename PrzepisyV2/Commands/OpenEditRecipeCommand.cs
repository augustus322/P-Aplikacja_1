using PrzepisyV2.Domain.Models;
using PrzepisyV2.Stores;
using PrzepisyV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzepisyV2.Commands
{
    public class OpenEditRecipeCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly RecipeListItemViewModel _recipeListItemViewModel;
        private readonly RecipeStore _recipeStore;

        public OpenEditRecipeCommand(RecipeListItemViewModel recipeListItemViewModel, RecipeStore recipeStore, ModalNavigationStore modalNavigationStore)
        {
            _recipeListItemViewModel = recipeListItemViewModel;
            _recipeStore = recipeStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            Recipe recipe = _recipeListItemViewModel.Recipe;

            EditRecipeViewModel editRecipeViewModel = new EditRecipeViewModel(recipe, _recipeStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editRecipeViewModel;
        }
    }
}
