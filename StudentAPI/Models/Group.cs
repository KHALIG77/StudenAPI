using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Models
{
    public class Group
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public List<GroupTeacher> Teachers { get; set; }
    }
}
