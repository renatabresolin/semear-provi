using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SemearApi.Entities
{
    [Table("USER")]
    public class User : DbContext
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Age { get; set; }

        public string Description { get; set; }

        public string linkedin { get; set; }

        public string GitHub { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<UserLearn> UserLearn { get; set; }
        public ICollection<UserCareers> UserCareers { get; set; }

        public ICollection<UserIntructs> UserIntructs { get; set; }

        /*public ICollection<Review> Reviews { get; set; }


        public string Classificacao()
        {
            int score = Reviews.Sum(s => s.Rating);

            if (score <= 10)
            {
                return "Semente";
            }
            else if (score >= 11 && score <= 20)
            {
                return "Broto";
            }

            if (score > 20)
            {
                return "Flor";
            }

            return "";
        }*/


        public User()
        {
        }


        public User(string name, string email, string password  )
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Role = Entities.Role.User;
           
        }


        public void ModifyLearns(List<int> learn)
        {
            UserLearn = new List<UserLearn>();
            foreach (var item in learn)
            {
                var userLearn = new UserLearn(Id, item);
                UserLearn.Add(userLearn);
            }
        }

        
        public void ModifyInstructs(List<int> intructs)
        {
            UserIntructs = new List<UserIntructs>();
            foreach (var item in intructs)
            {
                var userIntructs = new UserIntructs(Id, item);
                UserIntructs.Add(userIntructs);
            }
        }

        
    }
}