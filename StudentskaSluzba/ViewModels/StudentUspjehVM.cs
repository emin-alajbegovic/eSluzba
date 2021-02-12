using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSluzba.ViewModels
{
    public class StudentUspjehVM
    {
        public int Id { get; set; }
        [DisplayName("Predmet")]
        [Required]
        public int? PredmetId { get; set; }
        public int StudentId { get; set; }
        public DateTime? DatumPolaganja { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Ocjena je obavezna")]
        public int Ocjena { get; set; }
        public List<SelectListItem> Predmeti { get; set; }
        [DisplayName("Ocjene")]
        public int[] Ocjene { get; set; } = { 6, 7, 8, 9, 10 };
    }
}
