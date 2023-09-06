﻿using PrzepisyV2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzepisyV2.Domain.Queries
{
    public interface IGetAllRecipesQuery
    {
        Task<IEnumerable<Recipe>> Execute();
    }
}
