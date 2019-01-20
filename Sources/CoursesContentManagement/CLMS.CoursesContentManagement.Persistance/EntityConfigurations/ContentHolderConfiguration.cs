using CLMS.CoursesContentManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CLMS.CoursesContentManagement.Persistance.EntityConfigurations
{
    public class ContentHolderConfiguration : IEntityTypeConfiguration<ContentHolder>
    {
        public void Configure(EntityTypeBuilder<ContentHolder> builder)
        {
            builder.HasMany(x => x.Contents).WithOne();
        }
    }
}