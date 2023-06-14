using System.ComponentModel.DataAnnotations;

namespace StudentAPI.DTOs.Students
{
    public class StudenPostDTO
    {
        [Required]
        [MaxLength(25)]
        public string FullName {get; set;}
        [Required]
        [MaxLength(100)]
        public string Email {get; set;}
        [Required]
        [Range(0,100)]
        public int AvgPoint {get; set;}
        [Required]

        public int GroupId {get; set;}

    }
}
