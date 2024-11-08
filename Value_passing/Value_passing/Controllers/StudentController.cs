using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Value_passing.Models;

namespace Value_passing.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Education()
        {
            //ViewBag
            degree d1 = new degree()
            {
                Degname = "BSc in CSE",
                Institution = "AIUB",
                year = 2018,
                result = 3.5f
            }; 
            degree d2 = new degree()
            {
                Degname = "MSc in CSE",
                Institution = "AIUB",
                year = 2020,
                result = 3.7f
            };
            degree d3 = new degree()
            {
                Degname = "Phd",
                Institution = "AIUB",
                year = 2023,
                result = 3.8f
            };
            degree[] Degrees = new degree[] {d1,d2,d3};

            ViewBag.Degree = Degrees;

            //ViewData
            ViewData["message"] = "This is a message from ViewData";
            
            return View();
        }
        public ActionResult Qualification() {

            bool hasQualifacation = false;
            if (hasQualifacation)
            {
                return View();
            }
            else
            {
                TempData["message"] = "You don't have the required qualification";
                return RedirectToAction("Education");

            }
        }
        //modelBinding
        public ActionResult Experience()
        {
            experience e1 = new experience()
            {
                exp1 = "Intern",
                exp2 = "Junior Developer",
                exp3 = "Senior Developer"
            };
            experience e2 = new experience()
            {
                exp1 = "Intern2",
                exp2 = "Junior Developer2",
                exp3 = "Senior Developer2"
            };
            experience e3 = new experience()
            {
                exp1 = "Intern3",
                exp2 = "Junior Developer3",
                exp3 = "Senior Developer3"
            };
            experience[] Experiences = new experience[] { e1, e2, e3 };

            return View(Experiences);
        }

    }
}