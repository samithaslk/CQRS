using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot7.Architecture.Application.Context
{
    public interface IMyDbContext
    {
        DbSet<Dot7.Architecture.Domain.Entities.Beach> Beach { get; }

        Task<int> SaveToDbAsync();
    }
}
