namespace StudentAPI.DTOs.Students
{
    public class StudenGetDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email {get; set; }
        public int AvgPoint {get; set; }
        public GroupInStudentGetDTO Group { get; set; }

    }
    public class GroupInStudentGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }    
    }
}
