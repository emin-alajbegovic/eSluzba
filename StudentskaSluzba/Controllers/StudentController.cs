using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentskaSluzba.Data;
using StudentskaSluzba.Helper;
using StudentskaSluzba.Models;
using StudentskaSluzba.ViewModels;

namespace StudentskaSluzba.Controllers
{
    [Autorizacija(referent: true, student: false)]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string pretraga)
        {
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();

            if (korisnik == null)
            {
                TempData["error_poruka"] = "Nemate pravo pristupa";
                return RedirectToAction("Login", "Autentifikacija");
            }

            List<StudentiPrikazVM.Row> list =
                _db.Student.Where(s => pretraga == null || (s.Ime.ToLower() + " " + s.Prezime.ToLower()).StartsWith(pretraga.ToLower()))
                .Select(x => new StudentiPrikazVM.Row
                {
                    Id = x.Id,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    GodinaStudija = x.GodinaStudija.Godina,
                    Grad = x.Grad.Naziv,
                    AdresaStanovanja = x.AdresaStanovanja,
                    DatumRodjenja = x.DatumRodjenja,
                    JMBG = x.JMBG,
                    Email = x.Email,
                }).ToList();

            StudentiPrikazVM sp = new StudentiPrikazVM();
            sp.Studenti = list;
            sp.pretraga = pretraga;

            return View(sp);
        }

        public IActionResult Add()
        {
            IEnumerable<Grad> gradovi = _db.Grad.ToList();
            IEnumerable<GodinaStudija> godine = _db.GodinaStudja.ToList();

            ViewData["gradkey"] = gradovi;
            ViewData["godinekey"] = godine;
            Student student = new Student();
            ViewData["student"] = student;

            return View("Edit");
        }

        public IActionResult Poruka(int? id)
        {
            var student = _db.Student.Find(id);

            ViewData["student"] = student;
            return View();
        }

        // DELETE Student
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var obj = _db.Student.Find(id);
                _db.Remove(obj);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // ADD OR UPDATE
        public IActionResult AddEdit(int id)
        {
            List<SelectListItem> opstine = _db.Grad.Select(g => new SelectListItem
            {
                Text = g.Naziv,
                Value = g.Id.ToString()
            }).ToList();

            List<SelectListItem> godine = _db.GodinaStudja.Select(god => new SelectListItem
            {
                Text = god.Godina.ToString(),
                Value = god.Id.ToString()
            }).ToList();

            StudentVM student = id == 0 ? new StudentVM
            {
                Opcine = opstine,
                GodineStudija = godine
            } :
            _db.Student
                .Select(x => new StudentVM
                {
                    Id = x.Id,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    AdresaStanovanja = x.AdresaStanovanja,
                    DatumRodjenja = x.DatumRodjenja,
                    JMBG = x.JMBG,
                    Email = x.Email,
                    GodinaStudijaId = x.GodinaStudijaId,
                    GradId = x.GradId,
                    Opcine = opstine,
                    GodineStudija = godine
                })
                .Where(x => x.Id == id).Single();

            return View("AddEdit", student);
        }

        // ADD OR UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEdit(StudentVM s)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> opstine = _db.Grad.Select(g => new SelectListItem
                {
                    Text = g.Naziv,
                    Value = g.Id.ToString()
                }).ToList();

                List<SelectListItem> godine = _db.GodinaStudja.Select(god => new SelectListItem
                {
                    Text = god.Godina.ToString(),
                    Value = god.Id.ToString()
                }).ToList();

                s.Opcine = opstine;
                s.GodineStudija = godine;

                return View("AddEdit", s);
            }

            Student student;
            if (s.Id == 0)
            {
                student = new Student();
                _db.Add(student);
                TempData["poruka"] = "Uspjesno ste dodali studenta: ";
            }
            else
            {
                student = _db.Student.Find(s.Id);
                TempData["poruka"] = "Uspjesno ste editovali studenta: ";
            }

            student.Ime = s.Ime;
            student.Prezime = s.Prezime;
            student.AdresaStanovanja = s.AdresaStanovanja;
            student.GodinaStudijaId = s.GodinaStudijaId;
            student.GradId = s.GradId;
            student.JMBG = s.JMBG;
            student.DatumRodjenja = s.DatumRodjenja;
            student.Email = s.Email;

            _db.SaveChanges();

            TempData["poruka"] += student.ToString();
            return RedirectToAction("Poruka");
        }

        public IActionResult Uspjeh(int? id)
        {
            var student = _db.Student
                        .Include(s => s.Uspjeh)
                        .ThenInclude(s => s.Predmet)
                        .SingleOrDefault(s => s.Id == id);

            return View(student);
        }

        public IActionResult DeleteUspjeh(int? id)
        {
            if (id != null || id != 0)
            {
                var obj = _db.Uspjeh.Find(id);
                _db.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Uspjeh", new { id = obj.StudentId });
            }
            return RedirectToAction("Index");
        }

        public IActionResult AddUspjeh(int id)
        {
            if (id != 0)
            {
                List<SelectListItem> predmeti = _db.Predmet
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Naziv
                    }).ToList();
                StudentUspjehVM uspjeh = new StudentUspjehVM
                {
                    DatumPolaganja = DateTime.Now,
                    StudentId = id,
                    Predmeti = predmeti
                };
                return View("EditUspjeh", uspjeh);
            }

            return View("Index");
        }

        public IActionResult EditUspjeh(int id)
        {
            List<SelectListItem> predmeti = _db.Predmet
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv
                }).ToList();

            StudentUspjehVM u = _db.Uspjeh
                .Select(x => new StudentUspjehVM
                {
                    Id = x.Id,
                    PredmetId = x.PredmetId,
                    StudentId = x.StudentId,
                    DatumPolaganja = x.DatumPolaganja,
                    Ocjena = x.Ocjena,
                    Predmeti = predmeti
                })
                .Where(x => x.Id == id)
                .Single();

            return View(u);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditUspjeh(StudentUspjehVM sp)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> predmeti = _db.Predmet
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Naziv
                    }).ToList();

                sp.Predmeti = predmeti;

                return View(sp);
            }

            StudentiPredmeti uspjeh;
            if (sp.Id == 0)
            {
                uspjeh = new StudentiPredmeti();
                _db.Add(uspjeh);
            }
            else
            {
                uspjeh = _db.Uspjeh.Find(sp.Id);
            }

            uspjeh.Ocjena = sp.Ocjena;
            uspjeh.PredmetId = sp.PredmetId;
            uspjeh.StudentId = sp.StudentId;
            uspjeh.DatumPolaganja = sp.DatumPolaganja;

            _db.SaveChanges();
            return RedirectToAction("Uspjeh", new { id = uspjeh.StudentId });
        }
    }
}