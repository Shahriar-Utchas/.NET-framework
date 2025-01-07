using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService
    {
        public static List<StudentDTO> GetStudents()
        {
            var studentsData = new StudentRepo().GetStudents();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<StudentDTO>>(studentsData);
            return ret;
        }
        public static void AddStudent(StudentDTO s)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentDTO, Student>();
            });
            var mapper = new Mapper(config);
            var student = mapper.Map<Student>(s);
            new StudentRepo().AddStudent(student);
        }
        public static void UpdateStudent(StudentDTO s)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentDTO, Student>();
            });
            var mapper = new Mapper(config);
            var student = mapper.Map<Student>(s);
            new StudentRepo().UpdateStudent(student);

        }
        public static void DeleteStudent(int id)
        {
            new StudentRepo().DeleteStudent(id);
        }
    }
}
