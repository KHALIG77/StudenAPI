using StudentAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace StudentAPI.Configration
{
    public class GroupConfigration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
           builder.Property(x=>x.Name).IsRequired(true).HasMaxLength(20);
        }
    }


}
