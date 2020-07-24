using System.ComponentModel.DataAnnotations; // this allows access to required prevent null being entered. Make sure emails are being entered,phones numbers etc

namespace WebApplication1.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username {get;set;}

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters")]
        public string Password {get; set;}
    }
}