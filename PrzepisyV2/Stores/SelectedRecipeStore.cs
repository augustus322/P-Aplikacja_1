using PrzepisyV2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrzepisyV2.Stores
{
    public class SelectedRecipeStore
    {
        private readonly RecipeStore _recipeStore;

        public SelectedRecipeStore(RecipeStore recipeStore)
        {
            _recipeStore = recipeStore;
            _recipeStore.RecipeUpdated += recipeStore_RecipeUpdated;
        }

        private void recipeStore_RecipeUpdated(Recipe recipe)
        {
            if(recipe.Id == SelectedRecipe?.Id)
            {
                SelectedRecipe = recipe;
            }
        }

        private Recipe _selectedRecipe;
        public Recipe SelectedRecipe
        {
            get
            {
                return _selectedRecipe;
            }
            set
            {
                _selectedRecipe = value;
                SelectedRecipeChanged?.Invoke();
            }
        }
        
        public event Action SelectedRecipeChanged;
    }
}
