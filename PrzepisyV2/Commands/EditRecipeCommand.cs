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
    public class EditRecipeCommand : AsyncCommandBase
    {
        private readonly EditRecipeViewModel _editRecipeViewModel;
        private readonly RecipeStore _recipeStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public EditRecipeCommand(EditRecipeViewModel editRecipeViewModel, RecipeStore recipeStore, ModalNavigationStore modalNavigationStore)
        {
            _editRecipeViewModel = editRecipeViewModel;
            _recipeStore = recipeStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var formViewModel = _editRecipeViewModel.RecipeDetailsFormViewModel;

            Recipe recipe = new Recipe(_editRecipeViewModel.RecipeId, formViewModel.Name, formViewModel.Category, formViewModel.Description);

            try
            {
                await _recipeStore.Update(recipe);
                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
