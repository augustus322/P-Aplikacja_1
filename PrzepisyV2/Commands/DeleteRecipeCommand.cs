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
    public class DeleteRecipeCommand : AsyncCommandBase
    {
        private readonly RecipeListItemViewModel _recipeListItemViewModel;
        private readonly RecipeStore _recipeStore;

        public DeleteRecipeCommand(RecipeListItemViewModel recipeListItemViewModel, RecipeStore recipeStore)
        {
            _recipeListItemViewModel = recipeListItemViewModel;
            _recipeStore = recipeStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Recipe recipe = _recipeListItemViewModel.Recipe;

            try
            {
                await _recipeStore.Delete(recipe.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
