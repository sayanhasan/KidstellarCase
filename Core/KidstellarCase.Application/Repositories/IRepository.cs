using KidstellarCase.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidstellarCase.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
