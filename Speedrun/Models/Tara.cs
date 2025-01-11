using System.ComponentModel.DataAnnotations;

namespace Speedrun.Models
{
    public class Tara
    {
        [Key]
        public int CodTara { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Denumire { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Continent { get; set; }

        public virtual ICollection<Oras>? Orase { get; set; }
    }
}
