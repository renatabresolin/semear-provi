using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SemearApi.Entities
{
    [Table("REVIEWS")]
    public class Review : DbContext
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int Rating { get; set; }

        public int Content { get; set; }


      
    }
}