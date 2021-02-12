using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSluzba.Models
{
    public class GodinaStudija
    {
        [Key]
        public int Id { get; set; }
        public int Godina { get; set; }

        public ICollection<Student> Studenti { get; set; }
    }
}
