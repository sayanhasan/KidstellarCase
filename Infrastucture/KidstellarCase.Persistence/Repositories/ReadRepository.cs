using KidstellarCase.Application.Repositories;
using KidstellarCase.Domain.Entites;
using KidstellarCase.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KidstellarCase.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public ReadRepository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> GetByIdAsync(Guid id, bool tracking = true)
        {
            var table = Table.AsQueryable();
            if (!tracking) table = table.AsNoTracking();
            return await table.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public IQueryable<T> GetList(bool tracking = true)
        {
            var table = Table.AsQueryable();
            if (!tracking) table = table.AsNoTracking();
            return table;
        }

        public IQueryable<T> GetListByFilter(Expression<Func<T, bool>> filter = null, int? skip = null, int? take = null, string[] includes = null, bool orderByAsc = true, bool tracking = true)
        {
            var table = Table.AsQueryable();
            if (filter != null) table = Table.Where(filter);
            if (skip.HasValue) table = table.Skip(skip.GetValueOrDefault());
            if (take.HasValue) table = table.Take(take.GetValueOrDefault());
            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    table = table.Include(include);
                }
            }
            if (orderByAsc) table = table.OrderBy(x => x.Id);
            if (!tracking) table = table.AsNoTracking();
            return table;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            var table = Table.AsQueryable();
            if (!tracking) table = table.AsNoTracking();
            return await table.FirstOrDefaultAsync(filter);
        }
    }
}
