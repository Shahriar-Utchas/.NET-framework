using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRP_Management_System.EF;

namespace TRP_Management_System.Controllers
{
    public class ProgramController : Controller
    {
        TRP_Management_SystemEntities db = new TRP_Management_SystemEntities();

        // GET: Program
        public ActionResult ProgramList()
        {
            var programs = db.Programs.ToList();
            return View();
        }
    }
}