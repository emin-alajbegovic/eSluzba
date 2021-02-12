using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSluzba.Models
{
    public class Kanton
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public virtual int DrzavaId { get; set; }
        [ForeignKey("DrzavaId")]
        public virtual Drzava Drzava { get; set; }
    }
}
