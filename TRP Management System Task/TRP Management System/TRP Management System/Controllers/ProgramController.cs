using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRP_Management_System.DTOs;
using TRP_Management_System.EF;

namespace TRP_Management_System.Controllers
{
    public class ProgramController : Controller
    {
        TRP_Management_SystemEntities db = new TRP_Management_SystemEntities();

        //DTO Conversion
        public static Program Convert(ProgramDTO ProgramDTO)
        {
            return new Program
            {
                ProgramId = ProgramDTO.ProgramId,
                ProgramName = ProgramDTO.ProgramName,
                TRPScore = ProgramDTO.TRPScore,
                ChannelId = ProgramDTO.ChannelId,
                AirTime = ProgramDTO.AirTime
            };
        }
        public static ProgramDTO Convert(Program Program)
        {
            return new ProgramDTO
            {
                ProgramId = Program.ProgramId,
                ProgramName = Program.ProgramName,
                TRPScore = Program.TRPScore,
                ChannelId = Program.ChannelId,
                AirTime = Program.AirTime
            };
        }
        public static List<ProgramDTO> Convert(List<Program> Programs)
        {
            List<ProgramDTO> ProgramDTOs = new List<ProgramDTO>();
            foreach (var Program in Programs)
            {
                ProgramDTOs.Add(Convert(Program));
            }
            return ProgramDTOs;
        }


        // GET: Program
        public ActionResult ProgramList()
        {
            var programs = db.Programs.ToList();
            return View(Convert(programs));
        }
        [HttpGet]
        public ActionResult ProgramCreate()
        {
            ViewBag.Channels = db.Channels.ToList();
            return View(new Program());
        }
        [HttpPost]
        public ActionResult ProgramCreate(ProgramDTO Program)
        {
            ViewBag.Channels = db.Channels.ToList();
            if (ModelState.IsValid)
            {
                db.Programs.Add(Convert(Program));
                db.SaveChanges();
                return RedirectToAction("ProgramList");
            }
            return View(Program);
        }
    }
}