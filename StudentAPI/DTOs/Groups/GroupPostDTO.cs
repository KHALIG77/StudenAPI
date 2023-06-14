using System.ComponentModel.DataAnnotations;

namespace StudentAPI.DTOs.Groups
{
    public class GroupPostDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name {get;set;}
    }
}
