using KidstellarCase.Application.Repositories;
using KidstellarCase.Domain.Entites;
using KidstellarCase.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidstellarCase.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public WriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public Guid Add(T entity)
        {
            var model = Table.Add(entity);
            return model.Entity.Id;
        }

        public bool Remove(T entity)
        {
            var model = Table.Remove(entity);
            return model.State == EntityState.Deleted;
        }

        public bool RemoveById(int id)
        {
            var model = Table.FirstOrDefault(x => x.Id.Equals(id));
            return Remove(model);
        }

        public Guid Update(T entity)
        {
            var model = Table.Update(entity);
            return model.Entity.Id;
        }
    }
}
