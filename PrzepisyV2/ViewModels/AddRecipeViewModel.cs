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
    public class AddRecipeViewModel : ViewModelBase
    {
        public RecipeDetailsFormViewModel RecipeDetailsFormViewModel { get; }

        public AddRecipeViewModel(RecipeStore recipeStore, ModalNavigationStore modalNavigationStore)
        {
            ICommand submitCommand = new AddRecipeCommand(this, recipeStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            RecipeDetailsFormViewModel = new RecipeDetailsFormViewModel(submitCommand, cancelCommand);
        }
    }
}
