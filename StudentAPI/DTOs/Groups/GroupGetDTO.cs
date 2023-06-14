namespace StudentAPI.DTOs.Groups
{
    public class GroupGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentItemInGroupDTO> StudentInGroup { get; set; } 

    }
    public class StudentItemInGroupDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int AvgPoint { get; set; }
        public string Email { get; set; }
    }

}
