using Charity_Donation_Mid_Exam_.Auth;
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
    [AdminAccess]
    public class AdminController : Controller
    {
        Charity_DonationEntities db = new Charity_DonationEntities();
        // GET: Admin
        [HttpGet]
        public ActionResult CreateCampain()
        {
            return View(new CampainInfoDTO());
        }
        [HttpPost]
        public ActionResult CreateCampain(CampainInfoDTO c)
        {
            if (ModelState.IsValid)
            {
                CampainInfo camp = ConvertDTO.Convert(c);
                db.CampainInfoes.Add(camp);
                db.SaveChanges();
                TempData["CampMsg"] = "Campain Created Successfully";
                return RedirectToAction("CreateCampain", "Admin");
            }
            return View(c);
        }
    }
}