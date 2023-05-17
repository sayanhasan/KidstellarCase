using KidstellarCase.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidstellarCase.Application.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IReadRepository<User> UserReadRepo { get; }
        IWriteRepository<User> UserWriteRepo { get; }
        IParentReadRepository ParentReadRepo { get; }
        IWriteRepository<Parent> ParentWriteRepo { get; }
        Task<int> CommitAsync();
    }
}
