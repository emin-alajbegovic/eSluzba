using Microsoft.AspNetCore.Mvc.Rendering;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSluzba.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string AdresaStanovanja { get; set; }
        public string JMBG { get; set; }
        public string Email { get; set; }
        [Required]
        public int? GodinaStudijaId { get; set; }
        [Required]
        public int? GradId { get; set; }
        public List<SelectListItem> Opcine { get; set; }
        public List<SelectListItem> GodineStudija { get; set; }
    }
}
