using PrzepisyV2.Domain.Commands;
using PrzepisyV2.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzepisyV2.EntityFramework.Commands
{
    public class DeleteRecipeCommand : IDeleteRecipeCommand
    {
        private readonly RecipeDbContextFactory _contextFactory;

        public DeleteRecipeCommand(RecipeDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Guid id)
        {
            using (RecipeDbContext context = _contextFactory.Create())
            {
                RecipeDto recipeDto = new RecipeDto()
                {
                    Id = id,
                };

                context.Recipes.Remove(recipeDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
