using KidstellarCase.Domain.Entites;
using System.Linq.Expressions;

namespace KidstellarCase.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetList(bool tracking = true);
        IQueryable<T> GetListByFilter(Expression<Func<T, bool>> filter = null, int? skip = null, int? take = null, string[] includes = null, bool orderBy = true, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<T> GetByIdAsync(Guid id, bool tracking = true);
    }
}
