using PrzepisyV2.Domain.Models;
using PrzepisyV2.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzepisyV2.ViewModels
{
    public class RecipeDetailsViewModel : ViewModelBase
    {
        private readonly SelectedRecipeStore _selectedRecipeStore;
        private Recipe SelectedRecipe => _selectedRecipeStore.SelectedRecipe;
        public string Name => _selectedRecipeStore.SelectedRecipe?.Name ?? "brak";
        public string Category => _selectedRecipeStore.SelectedRecipe?.Category ?? "brak";
        public string Description => _selectedRecipeStore.SelectedRecipe?.Description ?? "brak";

        public RecipeDetailsViewModel(SelectedRecipeStore selectedRecipeStore)
        {
            _selectedRecipeStore = selectedRecipeStore;

            _selectedRecipeStore.SelectedRecipeChanged += SelectedRecipeStore_SelectedRecipeChanged;
        }

        protected override void Dispose()
        {
            _selectedRecipeStore.SelectedRecipeChanged -= SelectedRecipeStore_SelectedRecipeChanged;

            base.Dispose();
        }

        private void SelectedRecipeStore_SelectedRecipeChanged()
        {
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Category));
            OnPropertyChanged(nameof(Description));
        }
    }
}
