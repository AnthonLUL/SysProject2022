//using AbsenseApi.Receiver;
using AbsenseApi.Services;
using StudentLibrary;

namespace AbsenseApi.Managers
{
    public interface IAbsenseApiManager
    {
        DBService<Student> DbService { get; set; }
        List<Student> StudentList { get; set; }

        Student Add(Student newStudent);
        Student Delete(int studentId);
        List<Student> GetAllStudents();
        Student GetById(int studentId);
        Student GetByNFCId(long nFCId);
        Student Update(long nFCId, Student update);
    }
}