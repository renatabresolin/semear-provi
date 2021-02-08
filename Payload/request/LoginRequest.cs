using System.ComponentModel.DataAnnotations;

namespace SemearApi.Payload.request
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Token { get; set; }
    }
}