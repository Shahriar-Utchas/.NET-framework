using Entity_framework.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entity_framework.Controllers
{
    public class StudentController : Controller
    {
        testEntities db = new testEntities();
        // GET: Student
        public ActionResult list()
        {
            var data = db.students.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(student s)
        {
            db.students.Add(s);
            db.SaveChanges();
            TempData["Msg"] = "Student Created";
            return RedirectToAction("list");
        }
    }
}