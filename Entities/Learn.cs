using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SemearApi.Entities
{
    [Table("LEARNS")]
    public class Learn : DbContext
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public ICollection<UserLearn> UserLearn { get; set; }
    }
}