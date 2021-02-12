using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSluzba.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ime je obavezno")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Unesite datum rođenja")]
        public DateTime? DatumRodjenja { get; set; }
        [Required]
        public string AdresaStanovanja { get; set; }
        [Required]
        public string JMBG { get; set; }
        [Required]
        public string Email { get; set; }
        [ForeignKey("GodinaStudija")]
        [Required(ErrorMessage = "Odaberite godinu studija")]
        public int? GodinaStudijaId { get; set; }
        [Display(Name = "Godina studija")]
        public virtual GodinaStudija GodinaStudija { get; set; }
        [Required(ErrorMessage = "Odaberite mjesto stanovanja")]
        public int? GradId { get; set; }
        [ForeignKey("GradId")]
        public virtual Grad Grad { get; set; }

        public virtual List<StudentiPredmeti> Uspjeh { get; set; } = new List<StudentiPredmeti>();

        public override string ToString()
        {
            return $"{this.Ime} {this.Prezime}";
        }
    }
}
