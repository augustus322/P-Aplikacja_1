using PrzepisyV2.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzepisyV2.Commands
{
    public class LoadRecipesCommand : AsyncCommandBase
    {
        private readonly RecipeStore _recipeStore;
        public LoadRecipesCommand(RecipeStore recipeStore)
        {
            _recipeStore = recipeStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _recipeStore.Load();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
