//using AbsenseApi.Receiver;
using AbsenseApi.Services;
using Org.BouncyCastle.Bcpg.OpenPgp;
using StudentLibrary;
using AbsenseApi.MockData;
using System.Data.SqlClient;

namespace AbsenseApi.Managers
{
    public class AbsenseApiManager : IAbsenseApiManager
    {
        public DBService<Student> DbService { get; set; }

        public List<Student> StudentList { get; set; }



        //public List<Student> StudentList = new List<Student>();

        //public AbsenseApiManager(DBService<Student> dBService)
        //{
        //    DbService = dBService;
        //    //StudentList = MockStudents.GetAllStudents().ToList();
        //    //StudentList = dBService.GetObjectsAsync().Result.ToList();

        //}


        public List<Student> GetAllStudents()
        {
            StudentList = MockStudents.GetAllStudents().ToList();
            StudentList = DbService.GetObjectsAsync().Result.ToList();
            return StudentList;
        }


        public List<Student> GetAll(string name)
        {
            List<Student> students = new List<Student>(StudentList);
            if (name != null)
            {
                students = students.FindAll(students => students.Name != null && students.Name.StartsWith(name));
            }
            else if (name == null)
            {
                return students;
            }
            return students;
        }

        public Student GetById(int studentId)
        {
            return StudentList.Find(student => student.Id == studentId);
        }

        public Student GetByNFCId(long nFCId)
        {
            return StudentList.Find(student => student.NFCId == nFCId);
        }

        public Student Add(Student newStudent)
        {
            newStudent.NameValidatior();
            StudentList.Add(newStudent);
            return newStudent;
        }

        public Student Delete(int studentId)
        {
            Student students = StudentList.Find(student => student.Id == studentId);
            if (students == null) return null;
            StudentList.Remove(students);
            return students;
        }

        public Student Update(long nFCId, Student update)
        {
            Student? student = StudentList.Find(student => student.NFCId == nFCId);
            if (student == null) return null;
            student.NameValidatior();
            student.Name = update.Name;
            student.AbsenceMin = update.AbsenceMin;
            student.NFCId = update.NFCId;
            student.CheckedIn = update.CheckedIn;
            return student;
        }
    }
}
