using KidstellarCase.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidstellarCase.Persistence.EntityConfigurations
{
    public class UserParentEntityConfiguration : IEntityTypeConfiguration<UserParent>
    {
        public void Configure(EntityTypeBuilder<UserParent> builder)
        {
            builder.ToTable("dbo.userparent");
            builder.HasKey(x => new { x.UserId,x.ParentId });
            builder.HasOne(x=>x.User).WithMany(x=>x.Parents).HasForeignKey(x=>x.UserId);
            builder.HasOne(x=>x.Parent).WithMany(x=>x.Users).HasForeignKey(x=>x.ParentId);
        }
    }
}
