using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;
using SemearApi.Entities;

namespace SemearApi.Payload.response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Description { get; set; }
        public string Linkedin { get; set; }
        public string GitHub { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<string> Careeres  {get; set; }
        public List<int> Learns  {get; set; }
        public List<int> Intructs  {get; set; }
        
        public UserResponse(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Age = user.Age;
            Description = user.Description;
            Linkedin = user.linkedin;
            GitHub = user.GitHub;
            Password = user.Password;
            Role = user.Role;
            Careeres = user.UserCareers?.Select(s => s.Careers.Name).ToList();
            Learns = user.UserLearn?.Select(s => s.LearnId).ToList();
            Intructs = user.UserIntructs?.Select(s => s.IntructsId).ToList();
        }
    }
}