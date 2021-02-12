using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSluzba.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Grad> Grad { get; set; }
        public DbSet<Kanton> Kanton { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<ReferentStudentskeSluzbe> Referent { get; set; }
        public DbSet<GodinaStudija> GodinaStudja { get; set; }
        public DbSet<Predmet> Predmet { get; set; }
        public DbSet<StudentiPredmeti> Uspjeh { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<Test> Test { get; set; }
    }
}
