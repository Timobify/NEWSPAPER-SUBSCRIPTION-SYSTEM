using System.ComponentModel.DataAnnotations;

namespace NEWSPAPER_SUBSCRIPTION_SYSTEM.Models.Users
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}