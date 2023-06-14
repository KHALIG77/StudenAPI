namespace StudentAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int GroupId {get; set; }
        public int AvgPoint {get; set; }
        public Group Group { get; set; }
        public string Email {get; set; }

    }
}
