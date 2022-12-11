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
        public List<Student> StudentList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        public Student Update(long nFCId, Student update)
        {
            throw new NotImplementedException();
        }
    }
}
