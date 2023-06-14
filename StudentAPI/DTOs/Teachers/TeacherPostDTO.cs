using System.ComponentModel.DataAnnotations;

namespace StudentAPI.DTOs.Teachers
{
    public class TeacherPostDTO
    {
        [Required]
        [MaxLength(30)]
        public string Name {get; set;}

    }
}
