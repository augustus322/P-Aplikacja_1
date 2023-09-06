using Microsoft.EntityFrameworkCore;
using PrzepisyV2.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzepisyV2.EntityFramework
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RecipeDto> Recipes { get; set; }
    }
}
