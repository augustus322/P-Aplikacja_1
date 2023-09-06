using PrzepisyV2.Commands;
using PrzepisyV2.Domain.Models;
using PrzepisyV2.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrzepisyV2.ViewModels
{
    public class EditRecipeViewModel : ViewModelBase
    {
        public Guid RecipeId { get; }

        public RecipeDetailsFormViewModel RecipeDetailsFormViewModel { get; }

        public EditRecipeViewModel(Recipe recipe, RecipeStore recipeStore, ModalNavigationStore modalNavigationStore)
        {
            RecipeId = recipe.Id;

            ICommand submitCommand = new EditRecipeCommand(this, recipeStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            RecipeDetailsFormViewModel = new RecipeDetailsFormViewModel(submitCommand, cancelCommand)
            {
                Name = recipe.Name,
                Category = recipe.Category,
                Description = recipe.Description
            };
        }
    }
}
