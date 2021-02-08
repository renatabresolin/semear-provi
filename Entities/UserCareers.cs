using System.ComponentModel.DataAnnotations.Schema;

namespace SemearApi.Entities
{
    [Table("USER_CAREERS")]
    public class UserCareers
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int CareersId { get; set; }
        public Careers Careers { get; set; }
    }
}