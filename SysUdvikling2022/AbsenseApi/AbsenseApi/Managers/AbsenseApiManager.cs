//using AbsenseApi.Receiver;
using AbsenseApi.Services;
using Org.BouncyCastle.Bcpg.OpenPgp;
using StudentLibrary;

namespace AbsenseApi.Managers
{
    public class AbsenseApiManager
    {
        //public List<Student> StudentList = new List<Student>();

        //public UdpReceiver UdpReceiverAPI {get; set;}
        //public AbsenseApiManager(UdpReceiver udpReceiver)
        //{
        //    UdpReceiverAPI = udpReceiver;
        //}

        public AbsenseApiManager()
        {

        }

        public static int nextId = 1;
        private static readonly List<Student> StudentList = new List<Student>
        {
            new Student(studentId: nextId++,name: "Jonas", absenceMin: 24, nFCId: 1234, checkedIn: false),
            new Student(studentId: nextId++,name: "Anthon", absenceMin: 24, nFCId: 12123434, checkedIn: false),
            new Student(studentId: nextId++,name: "Anton", absenceMin: 24, nFCId: 12123434, checkedIn: false),
            new Student(studentId: nextId++,name: "Morten", absenceMin: 24, nFCId: 3413684765, checkedIn: false),
        };

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
            return StudentList.Find(student => student.StudentId == studentId);
        }

        public Student GetByNFCId(int nFCId)
        {
            return StudentList.Find(student => student.NFCId == nFCId);
        }

        public Student Add(Student newStudent)
        {
            newStudent.NameValidatior();
            newStudent.StudentId = nextId++;
            StudentList.Add(newStudent);
            return newStudent;
        }

        public Student Delete(int studentId)
        {
           Student students = StudentList.Find(student => student.StudentId == studentId);
           if (students == null)return null;
           StudentList.Remove(students);
           return students;
        }

        public Student Update(int nFCId, Student update)
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
