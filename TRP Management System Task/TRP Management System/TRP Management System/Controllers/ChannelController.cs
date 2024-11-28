using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRP_Management_System.DTOs;
using TRP_Management_System.EF;

namespace TRP_Management_System.Controllers
{
    public class ChannelController : Controller
    {
        TRP_Management_SystemEntities db = new TRP_Management_SystemEntities();

            public static Channel Convert(ChannelDTO channelDTO)
            {
                return new Channel
                {
                    ChannelId = channelDTO.ChannelId,
                    ChannelName = channelDTO.ChannelName,
                    EstablishYear = channelDTO.EstablishYear,
                    Country = channelDTO.Country
                };
            }
        public static ChannelDTO Convert(Channel channel)
        {
            return new ChannelDTO
            {
                ChannelId = channel.ChannelId,
                ChannelName = channel.ChannelName,
                EstablishYear = channel.EstablishYear,
                Country = channel.Country
            };
        }
        public static List<ChannelDTO> Convert(List<Channel> channels)
        {
            List<ChannelDTO> channelDTOs = new List<ChannelDTO>();
            foreach (var channel in channels)
            {
                channelDTOs.Add(Convert(channel));
            }
            return channelDTOs;
        }
        // GET: Channel
        public ActionResult ChannelList()
        {
            var channels = db.Channels.ToList();
            return View(Convert(channels));
        }
        [HttpGet]
        public ActionResult ChannelCreate()
        {
            return View(new Channel());
        }
        [HttpPost]
        public ActionResult ChannelCreate(ChannelDTO channel)
        {
            if (ModelState.IsValid)
            {
                db.Channels.Add(Convert(channel));
                db.SaveChanges();
                return RedirectToAction("ChannelList");
            }
            return View(channel);

        }
        [HttpGet]
        public ActionResult ChannelEdit(int id)
        {
            var channel = db.Channels.Find(id);
            return View(channel);
        }
        [HttpPost]
        public ActionResult ChannelEdit(ChannelDTO channel)
        {
           var channel_find = db.Channels.Find(channel.ChannelId);
                channel_find.ChannelName = channel.ChannelName;
                channel_find.EstablishYear = channel.EstablishYear;
                channel_find.Country = channel.Country;
                db.SaveChanges();
                return RedirectToAction("ChannelList");
        }
        [HttpGet]
        public ActionResult ChannelDelete(int id)
        {
            var channel = db.Channels.Find(id);
            if(channel == null)
            {
                return RedirectToAction("ChannelList");
            }
            return View(Convert(channel));
        }

        [HttpPost]
        public ActionResult ChannelDelete(ChannelDTO channel,string dcsn)
        {
            if (dcsn.Equals("Yes"))
            {
                var channel_find = db.Channels.Find(channel.ChannelId);
                //var programs = (from item in db.Programs
                //                where item.ChannelId == channel_find.ChannelId
                //                select item).ToList();
                //foreach (var program in programs)
                //{
                //    db.Programs.Remove(program);
                //    db.SaveChanges();
                //}
                var prog_exist = db.Programs.Where(x => x.ChannelId == channel_find.ChannelId).FirstOrDefault();
                if (prog_exist != null) {
                    TempData["DeleteMsg"] = "Programs are associated with this channel. You can't delete this channel.";
                    return RedirectToAction("ChannelList");
                }
                db.Channels.Remove(channel_find);
                db.SaveChanges();
            } 
                return RedirectToAction("ChannelList");
        }
        public ActionResult ProgramDetails(int id) {
            var programs = db.Programs.Where(x => x.ChannelId == id).ToList();
            return View(programs);
        }
    }
}