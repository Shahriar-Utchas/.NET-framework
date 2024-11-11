using EFwithDTO.DTOs;
using EFwithDTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFwithDTO.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
            practiceEntities db = new practiceEntities();
        //DTo conversion
        public static department convert(departmentDTO d)
        {
            return new department
            {
                ID = d.ID,
                Name = d.Name
            };
        }
        public static departmentDTO convert(department d)
        {
            return new departmentDTO
            {
                ID = d.ID,
                Name = d.Name
            };
        }
        public static List<departmentDTO> convert(List<department> d)
        {
            List<departmentDTO> dtos = new List<departmentDTO>();
            foreach (var item in d)
            {
                dtos.Add(convert(item));
            }
            return dtos;
        }
        public ActionResult List()
        {
            var departments = db.departments.ToList();
            return View(convert(departments));
        }
        [HttpGet]
        public ActionResult create() {

            return View(new department());
        }
        [HttpPost]
        public ActionResult create(departmentDTO d)
        {
            if(ModelState.IsValid)
            {
            db.departments.Add(convert(d));
            db.SaveChanges();
            return RedirectToAction("List");
            }
                return View(d);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var exObj = db.departments.Find(id);
            return View(convert(exObj));
        }
        [HttpPost]
        public ActionResult Edit(departmentDTO d)
        {
                var exObj = db.departments.Find(d.ID);
                exObj.Name = d.Name;
                db.SaveChanges();
                return RedirectToAction("List");
        }
        public ActionResult Details(int id)
        {
            var exObj = db.departments.Find(id);
            return View(convert(exObj));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var exObj = db.departments.Find(id);
            return View(convert(exObj));
        }
        [HttpPost]
        public ActionResult Delete(int id, string dcsn)
        {
            if (dcsn.Equals("Yes"))
            {
                var exObj = db.departments.Find(id);
                db.departments.Remove(exObj);
                db.SaveChanges();
            }
                return RedirectToAction("List");
            
        }
    }
}