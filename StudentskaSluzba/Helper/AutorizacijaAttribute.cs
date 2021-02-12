using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentskaSluzba.Data;
using StudentskaSluzba.Migrations;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSluzba.Helper
{
    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(bool referent, bool student) : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { referent, student };
        }
    }

    public class MyAuthorizeImpl : IAsyncActionFilter
    {
        public MyAuthorizeImpl(bool referent, bool student)
        {
            _referent = referent;
            _student = student;
        }

        private readonly bool _referent;
        private readonly bool _student;

        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            KorisnickiNalog k = Autentifikacija.GetLogiraniKorisnik(filterContext.HttpContext);
            //KorisnickiNalog k = filterContext.HttpContext.GetLogiraniKorisnik();

            if (k == null)
            {
                if (filterContext.Controller is Controller controller)
                {
                    controller.ViewData["error_poruka"] = "Niste logirani.";
                }
                filterContext.Result = new RedirectToActionResult("Login", "Autentifikacija", new { @area = "" });
                return;
            }

            // Preuzimamo DbContext preko app services
            ApplicationDbContext _db = filterContext.HttpContext.RequestServices.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

            // mogu pristupiti referenti
            if (_referent && _db.Referent.Any(r => r.Id == k.Id))
            {
                await next(); // ok - ima pravo pristupa
                return;
            }

            if (filterContext.Controller is Controller c1)
            {
                c1.TempData["error_poruka"] = "Nemate pravo pristupa";
            }
            filterContext.Result = new RedirectToActionResult("Index", "Predmet", new { @area = "" });
        }


    }
}
