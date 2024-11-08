using Form_validation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form_validation.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult Form()
        {
            return View(new student());
        }
        [HttpPost]
        public ActionResult Form(student s)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

                return View(s);
            
        }
    }
}