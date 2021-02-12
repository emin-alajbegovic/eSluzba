using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSluzba.Models
{
    public class ReferentStudentskeSluzbe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        public int? KorisnickiNalogId { get; set; }
        [ForeignKey("KorisnickiNalogId")]
        public virtual KorisnickiNalog KorisnickiNalog { get; set; }
        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }
    }
}
