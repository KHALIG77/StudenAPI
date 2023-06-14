using System.ComponentModel.DataAnnotations;

namespace StudentAPI.DTOs.Groups
{
    public class GroupPutDTO
    {
       [Required]
       [MaxLength(20)]
      public string Name {get;set;}

    }
}
