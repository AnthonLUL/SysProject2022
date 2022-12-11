using StudentLibrary;

namespace AbsenseApi.MockData
{
    public class MockStudents
    {
        private static List<Student> studentList = new List<Student>()
        {
            new (name: "Jonas", absenceMin: 24, nFCId: 1234, checkedIn: false),
            new (name: "Anthon", absenceMin: 24, nFCId: 12123434, checkedIn: false),
            new (name: "Anton", absenceMin: 24, nFCId: 12123434, checkedIn: false),
            new (name: "Morten", absenceMin: 24, nFCId: 3413684765, checkedIn: false),
        };

        public static List<Student> GetAllStudents()
        {
            return studentList;
        }
    }
}
