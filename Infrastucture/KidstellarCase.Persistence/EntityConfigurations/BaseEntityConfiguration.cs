using KidstellarCase.Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidstellarCase.Persistence.EntityConfigurations
{
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.FirstName).HasMaxLength(100);
            builder.Property(x=>x.LastName).HasMaxLength(100);
            builder.Property(x=>x.Username).HasMaxLength(100);
        }
    }
}
