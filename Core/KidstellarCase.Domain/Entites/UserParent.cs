using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidstellarCase.Domain.Entites
{
    public class UserParent
    {
        public Guid UserId { get; set; }
        public Guid ParentId { get; set; }
        public virtual User User { get; set; }
        public virtual Parent Parent { get; set; }
    }
}
