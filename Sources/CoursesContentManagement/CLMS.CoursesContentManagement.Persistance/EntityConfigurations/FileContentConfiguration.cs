using CLMS.CoursesContentManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CLMS.CoursesContentManagement.Persistance.EntityConfigurations
{
    public class FileContentConfiguration : IEntityTypeConfiguration<FileContent>
    {
        public void Configure(EntityTypeBuilder<FileContent> builder)
        {
            builder.HasOne<File>().WithOne(x => x.Content).HasForeignKey<File>(x => x.FileContentId);
        }
    }
}