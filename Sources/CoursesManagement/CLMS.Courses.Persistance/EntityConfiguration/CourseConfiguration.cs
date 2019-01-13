using CLMS.Courses.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CLMS.Courses.Persistance.EntityConfiguration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasOne(x => x.Holder).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}