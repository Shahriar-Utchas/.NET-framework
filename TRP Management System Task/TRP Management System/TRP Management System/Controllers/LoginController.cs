using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRP_Management_System.DTOs;
using TRP_Management_System.EF;

namespace TRP_Management_System.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        TRP_Management_SystemEntities db = new TRP_Management_SystemEntities();
        [HttpGet]
        public ActionResult Login()
        {

            return View(new loginDTO());
        }
        [HttpPost]
        public ActionResult Login(loginDTO login)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in db.logins
                            where u.User == login.User && u.Pass == login.Pass
                            select u).FirstOrDefault();
                if (user != null)
                {
                    Session["User"] = user;
                    return RedirectToAction("ProgramList", "Program");
                }

            }
            return View(login);
        }
    }
}