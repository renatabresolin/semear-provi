using System.ComponentModel.DataAnnotations.Schema;

namespace SemearApi.Entities
{
    [Table("USER_INSTRUCTS")]
    public class UserIntructs
    {
        
        public int UserId { get; set; }
        public User User { get; set; }
        public int IntructsId { get; set; }
        public Intructs Intructs { get; set; }


        public UserIntructs(int userId, int intructsId)
        {
            UserId = userId;
            IntructsId = intructsId;
        }
    }
}