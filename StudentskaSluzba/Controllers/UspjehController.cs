using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StudentskaSluzba.Controllers
{
    public class UspjehController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}