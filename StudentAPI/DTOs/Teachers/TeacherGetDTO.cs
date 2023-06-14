namespace StudentAPI.DTOs.Teachers
{
    public class TeacherGetDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<GroupInTeacher>  Groups { get; set; }
        public TeacherGetDTO()
        {
            Groups=new List<GroupInTeacher>();
        }

    }
    public class GroupInTeacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudenInGroup> Students {get; set;}
        public GroupInTeacher()
        {
            Students = new List<StudenInGroup>();
        }

    }
    public class StudenInGroup
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        
    }
}


