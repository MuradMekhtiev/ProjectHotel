namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please fill out this field.")]
        public string Username { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please fill out this field.")]
        public string Password { get; set; }
    }
}
