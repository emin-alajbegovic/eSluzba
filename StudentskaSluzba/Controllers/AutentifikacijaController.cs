using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Data;
using StudentskaSluzba.Helper;
using StudentskaSluzba.Migrations;
using StudentskaSluzba.Models;
using StudentskaSluzba.ViewModels;

namespace StudentskaSluzba.Controllers
{
    public class AutentifikacijaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AutentifikacijaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Login()
        {
            return View(new LoginVM()
            {
                ZapamtiPassword = true
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM podaci)
        {
            string email = podaci.Email;
            string lozinka = podaci.Lozinka;

            KorisnickiNalog korisnik = _db.KorisnickiNalog
                .SingleOrDefault(k => k.Lozinka == lozinka && k.Email == email);

            if (!ModelState.IsValid || korisnik == null)
            {
                TempData["error_poruka"] = "Pogrešan email ili lozinka!";
                return View(korisnik);
            }

            HttpContext.SetLogiraniKorisnik(korisnik);

            return RedirectToAction("Index", "Student");
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Autentifikacija");
        }
    }
}
