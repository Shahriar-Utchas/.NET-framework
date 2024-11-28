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
    public class UserController : Controller
    {
        Charity_DonationEntities db = new Charity_DonationEntities();

       [Logged]
        public ActionResult DonationPage()
        {
            var campains = db.CampainInfoes.ToList();
            return View(ConvertDTO.Convert(campains));
        }
        [HttpGet]
        public ActionResult Donate(int id) {
            ViewBag.camp = db.CampainInfoes.Find(id);
            return View(new DonationDTO());
        }
        [HttpPost]
        public ActionResult Donate(DonationDTO d)
        {
            if (ModelState.IsValid)
            {
                Donation don = ConvertDTO.Convert(d);
                db.Donations.Add(don);
                db.SaveChanges();
                TempData["DonMsg"] = "Donation Done Successfully";
                return RedirectToAction("DonationPage", "User");
            }
            ViewBag.camp = db.CampainInfoes.Find(d.CampainID);

            return View(d);
        }
        public ActionResult TrackDonations()
        {
            var donations_info = db.CampainInfoes.ToList();
            return View(donations_info);
        }
    }
}