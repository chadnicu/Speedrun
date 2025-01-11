using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Speedrun.Models
{
    public class Oras
    {
        [Key]
        public int CodOras { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Denumire { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        [DisplayName("Numar de locuitori")]
        public int NumarulLocuitori { get; set; }

        [ForeignKey("Tara")]
        [DisplayName("Tara")]
        [Required]
        public int CodTara { get; set; }

        [DisplayName("Țara")]
        public virtual Tara? Tara { get; set; }
    }
}
