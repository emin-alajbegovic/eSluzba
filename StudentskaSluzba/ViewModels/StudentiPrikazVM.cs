using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSluzba.ViewModels
{
    public class StudentiPrikazVM
    {
        public class Row
        {
            public int Id { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public DateTime? DatumRodjenja { get; set; }
            public string AdresaStanovanja { get; set; }
            public string JMBG { get; set; }
            public string Email { get; set; }
            public string Grad { get; set; }
            public int GodinaStudija { get; set; }
        }
        public List<Row> Studenti { get; set; }
        public string pretraga { get; set; }
    }
}
