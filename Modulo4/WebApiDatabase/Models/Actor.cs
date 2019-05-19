using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDatabase.Models
{
    [Table("actor")]
    public class Actor
    {
        [Key, Column("actor_id")]
        public int Id { get; set; }
        
        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

    }
}