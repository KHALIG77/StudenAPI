using Microsoft.EntityFrameworkCore;
using StudentAPI.Configration;
using StudentAPI.Models;

namespace StudentAPI.DAL
{
    public class CourseDbContext:DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options):base(options)
        {
            
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<GroupTeacher> GroupTeachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfigration).Assembly);
        }
    }
}
