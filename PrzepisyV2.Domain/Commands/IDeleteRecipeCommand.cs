using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzepisyV2.Domain.Commands
{
    public interface IDeleteRecipeCommand
    {
        Task Execute(Guid id);
    }
}
