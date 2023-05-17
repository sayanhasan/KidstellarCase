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
    public class ParentReadRepository : ReadRepository<Parent>, IParentReadRepository
    {
        public ParentReadRepository(AppDbContext context) : base(context)
        {
        }
        public IQueryable<Parent> GetUsersWithParentsByParentId(Guid id)
        {
            return Table.Include(u => u.Users).ThenInclude(up => up.User).Where(x=>x.Id.Equals(id));
        }
    }
}
