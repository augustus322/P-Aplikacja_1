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
    public class AddRecipeCommand : AsyncCommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly AddRecipeViewModel _addRecipeViewModel;
        private readonly RecipeStore _recipeStore;

        public AddRecipeCommand(AddRecipeViewModel addRecipeViewModel, RecipeStore recipeStore, ModalNavigationStore modalNavigationStore)
        {
            _addRecipeViewModel = addRecipeViewModel;
            _recipeStore = recipeStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var formViewModel = _addRecipeViewModel.RecipeDetailsFormViewModel;

            Recipe recipe = new Recipe(Guid.NewGuid(), formViewModel.Name, formViewModel.Category, formViewModel.Description);

            try
            {
                await _recipeStore.Add(recipe);
                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
