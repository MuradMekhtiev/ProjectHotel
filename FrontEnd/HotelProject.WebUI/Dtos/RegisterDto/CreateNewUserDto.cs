using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please fill out this field.")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please fill out this field.")]
        public string Surname { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please fill out this field.")]
        public string Username { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please fill out this field.")]
        public string City { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please fill out this field.")]
        public string Email { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please fill out this field.")]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please fill out this field.")]
        public string ConfirmPassword { get; set; }
    }
}
