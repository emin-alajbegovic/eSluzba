using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSluzba.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(100, ErrorMessage = "Email mora sadržavati minimalno 5 karaktera", MinimumLength = 5)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(100, ErrorMessage = "Lozinka mora sadržavati minimalno 6 karaktera", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }
        public bool ZapamtiPassword { get; set; }
    }
}
