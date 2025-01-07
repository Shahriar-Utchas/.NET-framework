using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class StudentRepo: Repo
    {
        
        public  List<Student> GetStudents()
        { 
            return db.Students.ToList();

        }
        public void AddStudent(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();
        }
        public void UpdateStudent(Student s) {
            var student = db.Students.Find(s.StudentID);
            student.StudentName = s.StudentName;
            db.SaveChanges();
        }
        public void DeleteStudent(int id)
        {
            var student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
        }
    }
}
