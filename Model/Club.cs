using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Football.Model
{
    public class Club
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClubId { get; set; }
       
        public string? ClubName { get; set; } 
        public ICollection<Players> Players { get; set; } = new List<Players>();
    }
}
