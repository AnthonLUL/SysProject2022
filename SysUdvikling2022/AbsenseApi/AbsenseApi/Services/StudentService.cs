//using AbsenseApi.Managers;
//using StudentLibrary;
//using AbsenseApi.Services;
//using MathNet.Numerics.Distributions;

//namespace AbsenseApi.Services
//{
//    public class StudentService
//    {
//        public List<Student> students { get; set; }
//        public DBService<Student> DbService { get; set; }

//        public StudentService(DBService<Student> dbService)
//        {
//            //students = Manager.GetAll("");

//            //students = DbService.GetObjectsAsync().Result.ToList();

//            //students = new List<Student>
//            //{
//            //    new Student(studentId: 1,name: "Jonas", absenceMin: 24, nFCId: 1234, checkedIn: false),
//            //    new Student(studentId: 2,name: "Anthon", absenceMin: 24, nFCId: 12123434, checkedIn: false),
//            //    new Student(studentId: 3,name: "Anton", absenceMin: 24, nFCId: 12123434, checkedIn: false),
//            //    new Student(studentId: 4,name: "Morten", absenceMin: 24, nFCId: 12123434, checkedIn: false),
//            //};


//            //foreach (Student student in students)
//            //{
//            //    dbService._dbService.AddObjectAsync(student);
//            //}
//        }

//        public async Task AddStudent(Student student)
//        {
//            students.Add(student);
//            await DbService.AddObjectAsync(student);
//        }

//        public List<Student> GetAllStudents()
//        {
//            return students;
//        }
//    }
//}
