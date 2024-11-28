using Charity_Donation_Mid_Exam_.DTOs;
using Charity_Donation_Mid_Exam_.EF;
using Charity_Donation_Mid_Exam_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Charity_Donation_Mid_Exam_.Controllers
{
    public class LoginController : Controller
    {
        Charity_DonationEntities db = new Charity_DonationEntities();

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginDTO());
        }
        [HttpPost]
        public ActionResult Login(LoginDTO log)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in db.Users
                        where u.Name == log.Name && u.Password == log.Password
                        select u).FirstOrDefault();
                if (user != null)
                {
                    var role = user.Role;
                    if(role == 1)
                    {
                    Session["User"] = user;
                    return RedirectToAction("DonationPage", "User");
                    }
                    else
                    {
                    Session["User"] = user;
                    return RedirectToAction("CreateCampain", "Admin");

                    }
                }
                else
                {
                    TempData["logMsg"] = "Invalid User";
                }
            }

            return View(log);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View(new UserDTO());
        }
        [HttpPost]
        public ActionResult Register(UserDTO u)
        {
            if(ModelState.IsValid)
            {
                User user = ConvertDTO.Convert(u);
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(u);
        }
    }
}