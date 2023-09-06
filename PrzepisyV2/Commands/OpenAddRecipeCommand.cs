using PrzepisyV2.Stores;
using PrzepisyV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrzepisyV2.Commands
{
    public class OpenAddRecipeCommand : CommandBase
    {
        private readonly RecipeStore _recipeStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddRecipeCommand(RecipeStore recipeStore, ModalNavigationStore modalNavigationStore)
        {
            _recipeStore = recipeStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            AddRecipeViewModel addRecipeViewModel = new AddRecipeViewModel(_recipeStore, _modalNavigationStore);

            _modalNavigationStore.CurrentViewModel = addRecipeViewModel;
        }
    }
}
