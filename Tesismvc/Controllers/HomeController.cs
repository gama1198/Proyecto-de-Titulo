using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tesismvc.Models;
namespace Tesismvc.Controllers
{

    public class HomeController : Controller
    {
        Sistema_Escolar_respladoEntities db = new Sistema_Escolar_respladoEntities();
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Profesor")]
        public ActionResult getUserList()
        {
            var user = db.user.ToList();
            return View(user);

        }
        [Authorize(Roles = "Admin")]
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Profesor")]
        public ActionResult Alumnos()
        {
            var user = db.user.ToList();
            return View();
        }
    }
}
