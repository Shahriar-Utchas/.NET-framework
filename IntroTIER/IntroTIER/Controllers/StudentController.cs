using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroTIER.Controllers
{
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("api/students/getStudents")]
        public HttpResponseMessage GetStudents()
        {
            var students = StudentService.GetStudents();
            return Request.CreateResponse(HttpStatusCode.OK, students);
        }
        [HttpPost]
        [Route("api/students/addStudent")]
        public HttpResponseMessage AddStudent(StudentDTO s)
        {
            StudentService.AddStudent(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpPost]
        [Route("api/students/updateStudent")]
        public HttpResponseMessage UpdateStudent(StudentDTO s)
        {
            StudentService.UpdateStudent(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpPost]
        [Route("api/students/deleteStudent/{id}")]
        public HttpResponseMessage DeleteStudent(int id)
        {
            StudentService.DeleteStudent(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
