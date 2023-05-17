using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidstellarCase.Domain.Entites
{
    public class User : BaseEntity
    {
        public virtual ICollection<UserParent> Parents { get; set; }
    }
}
