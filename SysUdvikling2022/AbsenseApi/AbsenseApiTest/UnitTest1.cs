using AbsenseApi.Managers;
using Microsoft.AspNetCore.Routing;
using Org.BouncyCastle.Utilities;
using StudentLibrary;

namespace AbsenseApiTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetAll()
        {
            // Arrange
            var studentList = new List<Student>();
            AbsenseApiManager absenseApiManager = new AbsenseApiManager(studentList);
            var expectedCount = 4;


            // Act
            var result = absenseApiManager.GetAllStudents("A");
            

            // Assert
            Assert.IsNotNull(result);
            
            Assert.AreEqual(expectedCount, result.Count());
        }


        [TestMethod]
        public void TestAddMethod()
        {
            // Arrange
            var student = new Student("John", 22, 1234232, false);
            var studentList = new List<Student>();
            var studentService = new AbsenseApiManager(studentList);

            // Act
            var result = studentService.Add(student);

            // Assert
            Assert.AreEqual(student, result);
            Assert.IsTrue(studentList.Contains(student));
        }
        [TestMethod]
        public void TestUpdateMethod()
        {
            //Arrange
            var student = new Student("John", 22, 1234232, false);
            var studentList = new List<Student>();
            var studentService = new AbsenseApiManager(studentList);
            
            //Act
            var result = studentService.Add(student);
            result = studentService.Update(1234232);



            //Assert
            Assert.IsTrue(student.CheckedIn);

        }
        [TestMethod]
        public void TestDeleteMethod()
        {
            // Arrange
            var studentId = 1;
            var student = new Student { Id = studentId, Name = "John" };
            var studentList = new List<Student> { student };
            var studentService = new AbsenseApiManager(studentList);

            // Act
            var result = studentService.Delete(studentId);

            // Assert
            Assert.AreEqual(student, result);
            Assert.IsFalse(studentList.Contains(student));

        }
    }
}