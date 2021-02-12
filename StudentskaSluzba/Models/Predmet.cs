using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSluzba.Models
{
    public class Predmet
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string ETCS { get; set; }
        public virtual ICollection<StudentiPredmeti> Uspjeh { get; set; } = new List<StudentiPredmeti>();
    }
}
