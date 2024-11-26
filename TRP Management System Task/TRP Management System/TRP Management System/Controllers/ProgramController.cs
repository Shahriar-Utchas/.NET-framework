using System;
using System.Collections.Generic;
using System.Data.Entity;
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


        [HttpGet]
        public ActionResult ProgramList()
        {
            var channel_list = db.Channels.ToList();
            ViewBag.Channels = db.Channels.ToList();
            return View(channel_list);
        }
        [HttpPost]
        public ActionResult ProgramList(int Id)
        {
            var filtered_channel = (from item in db.Channels
                                    where item.ChannelId == Id
                                    select item).ToList();
            ViewBag.SelectedChannelId = Id;
            ViewBag.Channels = db.Channels.ToList();
            return View(filtered_channel);
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
        [HttpGet]
        public ActionResult ProgramEdit(int id)
        {
            var Program = db.Programs.Find(id);
            return View(Program);
        }
        [HttpPost]
        public ActionResult ProgramEdit(ProgramDTO Program)
        {
            if (ModelState.IsValid)
            {
                var program_find = db.Programs.Find(Program.ProgramId);
                program_find.ProgramName = Program.ProgramName;
                program_find.TRPScore = Program.TRPScore;
                program_find.AirTime = Program.AirTime;
                db.SaveChanges();
                return RedirectToAction("ProgramList");
            }
            return View(Program);
        }
        [HttpGet]
        public ActionResult ProgramDelete(int id)
        {
            var program = db.Programs.Find(id);
            return View(Convert(program));
        }
        [HttpPost]
        public ActionResult ProgramDelete(ProgramDTO program, string dcsn)
        {
            if (dcsn.Equals("Yes"))
            {
                var program_find = db.Programs.Find(program.ProgramId);
                db.Programs.Remove(program_find);
                db.SaveChanges();
            }
            return RedirectToAction("ProgramList");

        }
        

    }
}