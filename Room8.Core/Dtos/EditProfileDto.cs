using System.ComponentModel.DataAnnotations;

namespace Room8.API.Dtos
{
    public class EditProfileDto
    {
        public string? UserId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "Minimum of 7 charaters")]
        //public string Password { get; set; } = "";
        public string Firstname { get; set; } = "";
        public string Lastname { get; set; } = "";
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Location { get; set; } = "";
        public string Occupation { get; set; } = "";


    }
}
