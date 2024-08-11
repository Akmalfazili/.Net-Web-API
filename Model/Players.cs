using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Football.Model
{
    public class Players
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId {  get; set; }
        public string Name { get; set; }
        public int Appearances { get; set; }
        public int ClubId { get; set; }
        public Club Club { get; set; }
        
    }
}
