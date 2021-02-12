using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentskaSluzba.Data;
using StudentskaSluzba.Helper;
using StudentskaSluzba.Models;

namespace StudentskaSluzba.Controllers
{
    [Autorizacija(referent:true, student:false)]
    public class PredmetController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PredmetController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string pretraga)
        {
            List<Predmet> predmeti;
            if (!string.IsNullOrEmpty(pretraga))
            {
                predmeti = _db.Predmet.Where(p => p.Naziv.ToLower().StartsWith(pretraga.ToLower())).ToList();
            }
            else
            {
                predmeti = _db.Predmet.ToList();
            }
            ViewData["predmeti"] = predmeti;
            ViewData["pretraga"] = pretraga;

            return View();
        }

        public IActionResult AddEditPredmet(int id)
        {
            var predmet = id == 0 ? new Predmet() : _db.Predmet.Find(id);

            return View(predmet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEditPredmet(Predmet predmet)
        {
            Predmet p;
            if (predmet.Id == 0)
            {
                p = new Predmet();
                _db.Predmet.Add(p);
                TempData["poruka_p"] = "Uspjesno dodan predmet: ";
            }
            else
            {
                p = _db.Predmet.Find(predmet.Id);
                TempData["poruka_p"] = "Uspjesno uređen predmet: ";
            }

            p.ETCS = predmet.ETCS;
            p.Naziv = predmet.Naziv;

            if (!ModelState.IsValid)
            {
                return View(p);
            }

            _db.SaveChanges();
            TempData["poruka_p"] += p.Naziv;

            return View("Poruka");
        }

        public IActionResult Delete(int? id)
        {
            if (id != null || id != 0)
            {
                var obj = _db.Predmet.Find(id);
                _db.Remove(obj);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}