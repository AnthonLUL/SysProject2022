using AbsenseApi.DBContext;
using AbsenseApi.Services;
using Microsoft.EntityFrameworkCore;
using StudentLibrary;

namespace AbsenseApi.Managers
{
    public class AbsenseApiManagerDB : IAbsenseApiManager
    {
        
        private StudentContext _context;

        public AbsenseApiManagerDB(StudentContext context)
        {
            _context = context;
        }

        public DBService<Student> DbService { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Student> StudentList { get; set; }

        public Student Add(Student newStudent)
        {
            newStudent.Id = 0;
            _context.Students.Add(newStudent);
            _context.SaveChanges();
            return newStudent;

        }

        public Student Delete(int studentId)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int studentId)
        {
            throw new NotImplementedException();
        }

        public Student GetByNFCId(long nFCId)
        {
            throw new NotImplementedException();
        }

        public Student Update(long nFCId)
        {
            List<Student> Students = _context.Students.ToList();
            Student? student = Students.Find(student => student.NFCId == nFCId);
            if (student == null) return null;
            student.CheckedIn =! student.CheckedIn;
            _context.SaveChanges();
            return student;
        }
    }
}
