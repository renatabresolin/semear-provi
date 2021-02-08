using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SemearApi.Entities
{
    [Table("CARRERS")]
    public class Careers : DbContext
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public ICollection<UserCareers> UserCareers { get; set; }
    }
}