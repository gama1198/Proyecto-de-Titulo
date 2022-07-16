using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tesismvc.Models;

namespace AuthenticationDemo.Controllers
{
    public class AccountController : Controller
    {
        Sistema_Escolar_respladoEntities db = new Sistema_Escolar_respladoEntities();
        // GET: Account
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(user u)
        {
            if (ModelState.IsValid)
            {
                db.user.Add(u);
                if (db.SaveChanges() > 0)
                {
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(user u, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = db.user.Where(x => x.username == u.username && x.password == u.password).FirstOrDefault();
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(u.username, false);
                    Session["uname"] = u.username.ToString();
                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return Redirect("/Home/Index");
                    }
                }
            }

            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["uname"] = null;
            return Redirect("Login");
        }
    }
}
