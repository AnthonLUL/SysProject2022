using AbsenseApi.DBContext;
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

        //public DBService<Student> DbService { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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
            List<Student> Students = _context.Students.ToList();
            Student? student = Students.Find(student => student.Id == studentId);
            if (student == null) return null;
            _context.Students.Remove(student);
            _context.SaveChanges();
            return student;
        }

        public List<Student> GetAllStudents(string? name)
        {
            if (name != null)
            {
                StudentList = _context.Students.ToList();
                StudentList = StudentList.FindAll(students => students.Name != null && students.Name.StartsWith(name));
                return StudentList;
            }
            else if(name == null)
            {
                return _context.Students.ToList();
            }
            return _context.Students.ToList();
        }

        public Student GetByNFCId(long nFCId)
        {
            List<Student> Students = _context.Students.ToList();
            Student? student = Students.Find(student => student.NFCId == nFCId);
            if (student == null) return null;
            return student;
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
