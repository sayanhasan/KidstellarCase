using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidstellarCase.Domain.Entites
{
    public class Parent : BaseEntity
    {
        public DateTime BirthDate { get; set; }
        public virtual ICollection<UserParent> Users { get; set; }
    }
}
