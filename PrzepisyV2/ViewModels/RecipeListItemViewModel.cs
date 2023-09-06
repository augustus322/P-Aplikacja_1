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
    public class RecipeListItemViewModel : ViewModelBase
    {
        public Recipe Recipe { get; private set; }
        public string Name => Recipe.Name;

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public RecipeListItemViewModel(Recipe recipe, RecipeStore recipeStore, ModalNavigationStore _modalNavigationStore)
        {
            Recipe = recipe;

            EditCommand = new OpenEditRecipeCommand(this, recipeStore, _modalNavigationStore);
            DeleteCommand = new DeleteRecipeCommand(this, recipeStore);
        }

        public void Update(Recipe recipe)
        {
            Recipe = recipe;

            OnPropertyChanged(nameof(Name));
        }


    }
}
