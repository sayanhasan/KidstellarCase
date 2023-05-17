using KidstellarCase.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KidstellarCase.Application.Repositories
{
    public interface IParentReadRepository:IReadRepository<Parent>
    {
        public IQueryable<Parent> GetUsersWithParentsByParentId(Guid id);
    }
}
