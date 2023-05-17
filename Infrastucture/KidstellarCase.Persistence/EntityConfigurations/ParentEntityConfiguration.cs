using KidstellarCase.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace KidstellarCase.Persistence.EntityConfigurations
{
    public class ParentEntityConfiguration : BaseEntityConfiguration<Parent>
    {
        public override void Configure(EntityTypeBuilder<Parent> builder)
        {
            base.Configure(builder);
            builder.ToTable("dbo.parent");
        }

    }
}
