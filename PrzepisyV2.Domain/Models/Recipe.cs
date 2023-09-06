using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzepisyV2.Domain.Models
{
    public class Recipe
    {
        public Guid Id { get; } 
        public string Name { get; }
        public string Category { get; }
        public string Description { get; }

        public Recipe(Guid id, string name, string category, string description)
        {
            Id = id;
            Name = name;
            Category = category;
            Description = description;
        }
    }
}
