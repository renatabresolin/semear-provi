using System.ComponentModel.DataAnnotations.Schema;

namespace SemearApi.Entities
{
    [Table("USER_LEARN")]
    public class UserLearn
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int LearnId { get; set; }
        public Learn Learn { get; set; }


        public UserLearn(int userId, int learnId)
        {
            UserId = userId;
            LearnId = learnId;
        }
    }
}