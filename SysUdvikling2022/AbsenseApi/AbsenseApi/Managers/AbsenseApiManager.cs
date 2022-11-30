using StudentLibrary;

namespace AbsenseApi.Managers
{
    public class AbsenseApiManager
    {
        public static int nextId = 1;
        private static readonly List<Students> StudentsList = new List<Students>
        {
            new Students(studentId: nextId++,name: "Jonas", absenceMin: 24, nFCId: 12123434),
            new Students(studentId: nextId++,name: "Anthon", absenceMin: 24, nFCId: 12123434),
            new Students(studentId: nextId++,name: "Anton", absenceMin: 24, nFCId: 12123434),
            new Students(studentId: nextId++,name: "Morten", absenceMin: 24, nFCId: 12123434),
        };

        public List<Students> GetAll()
        {
            List<Students> students = new List<Students>(StudentsList);
            return students;
        }

        public Students GetById(int studentId)
        {
            return StudentsList.Find(student => student.StudentId == studentId);
        }

        public Students GetByName(string name)
        {
            return StudentsList.Find(student => student.Name == name);
        }

        public Students Add(Students newStudents)
        {
            newStudents.StudentId = nextId++;
            StudentsList.Add(newStudents);
            return newStudents;
        }

        public Students Delete(int studentId)
        {
           Students students = StudentsList.Find(student => student.StudentId == studentId);
           if (students == null)return null;
           StudentsList.Remove(students);
           return students;
        }

        public Students Update(int studentId, Students update)
        {
            Students? students = StudentsList.Find(student => student.StudentId == studentId);
            if (students == null) return null;
            students.Name = update.Name;
            students.AbsenceMin = update.AbsenceMin;
            students.NFCId = update.NFCId;
            return students;
        }
    }
}
