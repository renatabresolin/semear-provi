using System.ComponentModel.DataAnnotations;
using System.Linq;
using SemearApi.Entities;

namespace SemearApi.Payload.request
{
    public class UserCreateRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required]
        public string Name { get; set; }
       
        public int  Id { get; set; }
 
        public string  Role { get; set; }
        
        
        public int[] learn { get; set; }
        
        public int[] instruct { get; set; }
        
        public User Convert()
        {
            return new User(Name,UserName,Password);
        }
        
        public UserCreateRequest(User user)
        {
            UserName =user.Email;
            Name = user.Name;
            Role = user.Role;
            Id = user.Id;
        }

        public UserCreateRequest()
        {
            
        }  
    }
}