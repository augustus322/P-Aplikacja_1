using Microsoft.EntityFrameworkCore;
using PrzepisyV2.Domain.Models;
using PrzepisyV2.Domain.Queries;
using PrzepisyV2.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrzepisyV2.EntityFramework.Queries
{
    public class GetAllRecipesQuery : IGetAllRecipesQuery
    {
        private readonly RecipeDbContextFactory _contextFactory;

        public GetAllRecipesQuery(RecipeDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Recipe>> Execute()
        {
            using(RecipeDbContext context = _contextFactory.Create())
            {
                IEnumerable<RecipeDto> recipeDtos = await context.Recipes.ToListAsync();

                return recipeDtos.Select(y => new Recipe(y.Id, y.Name, y.Category, y.Description));
            }
        }
    }
}
