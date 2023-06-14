namespace StudentAPI.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<GroupTeacher> Groups { get; set; }

        
    }
}
