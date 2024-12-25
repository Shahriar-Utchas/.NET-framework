using IntroAPI.EF;
using IntroAPI.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroAPI.Controllers
{
    public class StudentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello from StudentController,Get method");
        }
        public HttpResponseMessage Post() {
            return Request.CreateResponse(HttpStatusCode.BadGateway, "Hello from StudentController,Post method");
        }
    StudentContext db = new StudentContext();

        [HttpGet]
        [Route("api/Student/GetStudents")]
        public HttpResponseMessage GetStudents()
        {
            var students = db.students.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, students);
        }

        [HttpGet]
        [Route("api/Student/GetStudent/{id}")]
        public HttpResponseMessage GetStudent(int id)
        {
            var student = db.students.Find(id);
            if (student == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Student not found");
            }
            else
            {
            return Request.CreateResponse(HttpStatusCode.OK, student);
            }
        }


        [HttpPost]
        [Route("api/Student/AddStudent")]
        public HttpResponseMessage AddStudent(Student student)
        {
            db.students.Add(student);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Student added successfully");
        }
    }
}
