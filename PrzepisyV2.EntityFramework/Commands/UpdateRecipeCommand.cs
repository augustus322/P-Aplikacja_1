using PrzepisyV2.Domain.Commands;
using PrzepisyV2.Domain.Models;
using PrzepisyV2.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzepisyV2.EntityFramework.Commands
{
    public class UpdateRecipeCommand : IUpdateRecipeCommand
    {
        private readonly RecipeDbContextFactory _contextFactory;

        public UpdateRecipeCommand(RecipeDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Recipe recipe)
        {
            using (RecipeDbContext context = _contextFactory.Create())
            {
                RecipeDto recipeDto = new RecipeDto()
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    Category = recipe.Category,
                    Description = recipe.Description,
                };

                context.Recipes.Update(recipeDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
