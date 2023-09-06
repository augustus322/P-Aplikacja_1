using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzepisyV2.EntityFramework
{
    public class RecipeDbContextFactory
    {
        private readonly DbContextOptions _options;

        public RecipeDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public RecipeDbContext Create()
        {
            return new RecipeDbContext(_options);
        }
    }
}
