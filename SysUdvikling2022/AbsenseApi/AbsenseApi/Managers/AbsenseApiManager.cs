using StudentLibrary;
using AbsenseApi.MockData;

namespace AbsenseApi.Managers
{
    public class AbsenseApiManager : IAbsenseApiManager
    {
        public AbsenseApiManager(List<Student> studentList)
        {
            StudentList = studentList;
        }

        public List<Student> StudentList { get; set; }

        public List<Student> GetAllStudents(string name)
        {
            StudentList = MockStudents.GetAllStudents().ToList();
            return StudentList;
        }


        public List<Student> GetAll(string? name)
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

        public Student Update(long nFCId)
        {
            Student? student = StudentList.Find(student => student.NFCId == nFCId);
            if (student == null) return null;
            student.NameValidatior();
            return student;
        }
    }
}
