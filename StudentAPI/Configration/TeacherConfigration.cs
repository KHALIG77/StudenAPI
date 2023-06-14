using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAPI.Models;

namespace StudentAPI.Configration
{
    public class TeacherConfigration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(x => x.FullName).IsRequired(true).HasMaxLength(30);
        }
    }
}
