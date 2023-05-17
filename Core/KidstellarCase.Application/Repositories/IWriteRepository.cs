using KidstellarCase.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidstellarCase.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Guid Add(T entity);
        bool Remove(T entity);
        bool RemoveById(int id);
        Guid Update(T entity);
    }
}
