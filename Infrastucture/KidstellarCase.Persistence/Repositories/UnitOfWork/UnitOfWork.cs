using KidstellarCase.Application.Repositories.UnitOfWork;
using KidstellarCase.Application.Repositories;
using KidstellarCase.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KidstellarCase.Domain.Entites;

namespace KidstellarCase.Persistence.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed = false;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IReadRepository<User> UserReadRepo => new ReadRepository<User>(_context);

        public IWriteRepository<User> UserWriteRepo => new WriteRepository<User>(_context);

        public IParentReadRepository ParentReadRepo => new ParentReadRepository(_context);

        public IWriteRepository<Parent> ParentWriteRepo => new WriteRepository<Parent>(_context);


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
