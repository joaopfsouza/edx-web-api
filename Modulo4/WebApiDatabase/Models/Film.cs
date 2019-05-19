using System.ComponentModel.DataAnnotations;

namespace WebApiDatabase.Models
{
    public class Film
    {
        [Key]
        public int Film_Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Release_Year { get; set; }

    }
}