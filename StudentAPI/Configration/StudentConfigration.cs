using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAPI.Models;

namespace StudentAPI.Configration
{
    public class StudentConfigration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x=>x.FullName).HasMaxLength(25).IsRequired(true);
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.AvgPoint).IsRequired(true);
            builder.HasOne(x=>x.Group).WithMany(x=>x.Students).HasForeignKey(x=>x.GroupId).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
