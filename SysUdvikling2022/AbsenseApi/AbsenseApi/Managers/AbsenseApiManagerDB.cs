using AbsenseApi.DBContext;
using AbsenseApi.MockData;
using AbsenseApi.Models;
using NPOI.SS.Formula.Functions;
using SQLitePCL;
using StudentLibrary;
using System;

namespace AbsenseApi.Managers
{
    public class AbsenseApiManagerDB : IAbsenseApiManager
    {
        
        private StudentContext _context;
        public List<Student> StudentList;

        public AbsenseApiManagerDB(StudentContext context)
        {
            _context = context;
            StudentList = _context.Students.ToList();
        }
        
        //public DBService<Student> DbService { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        

        public Student Add(Student newStudent)
        {
            newStudent.Id = 0;
            _context.Students.Add(newStudent);
            _context.SaveChanges();
            return newStudent;
        }

        public Student Delete(int studentId)
        {
            Student? student = StudentList.Find(student => student.Id == studentId);
            if (student == null) return null;
            _context.Students.Remove(student);
            _context.SaveChanges();
            return student;
        }

        public List<Student> GetAllStudents(string? name)
        {
            if (name != null)
            {
                StudentList = StudentList.FindAll(students => students.Name != null && students.Name.StartsWith(name));
                return StudentList;
            }
            
            else return StudentList;
        }

        public Student GetByNFCId(long nFCId)
        {
            Student? student = StudentList.Find(student => student.NFCId == nFCId);
            if (student == null) return null;
            return student;
        }

        public Student Update(long nFCId)
        {
            Student? student2 = GetByNFCId(nFCId);
            DateTime thistime = DateTime.Now;
            
            if (student2 == null) return null;
            student2.CheckedIn = !student2.CheckedIn;
            AbsenseTime absenseTimeStamp = new AbsenseTime(thistime, student2.Id, student2.CheckedIn);
            DateTime starttime = new DateTime(thistime.Year, thistime.Month, thistime.Day, 09, 10, 00);
            DateTime Endtime = new DateTime(thistime.Year, thistime.Month, thistime.Day, 14, 50, 00);


            double defaultDif = (Endtime - starttime).TotalMinutes;
            double floornumber = Math.Floor(defaultDif);
            int DefaultDifferenceMin = (int)floornumber; 

            double yourDif = (thistime - Endtime).TotalMinutes;
            double floornumber2 = Math.Floor(yourDif);
            int YourDifferenceMin = (int)floornumber2;

            if (YourDifferenceMin < DefaultDifferenceMin)
            {
                int YourAbsenceMin = DefaultDifferenceMin - YourDifferenceMin;
                student2.AbsenceMin = +YourAbsenceMin;
            }

            _context.AbsenseTime.Add(absenseTimeStamp);
            _context.SaveChanges();


            if(thistime.Hour > Endtime.Hour) // Vores check folk ud, burde være i en service der kører på systemet uden om API
            {
                foreach(Student singleStudent in StudentList)
                {
                    singleStudent.CheckedIn = false;
                    _context.SaveChanges();
                }
                
            }
            return student2;
        }
    }
}
