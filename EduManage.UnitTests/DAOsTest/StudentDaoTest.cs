using System;
using System.Collections.Generic;
using System.Linq;
using EduManage.BusinessObjects.Context;
using EduManage.BusinessObjects.Entities;
using EduManage.DAOs;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace EduManage.UnitTesting.DAOsTest
{
    public class StudentDaoTest
    {
        private readonly Mock<DbSet<Student>> _mockSet;
        private readonly Mock<ApplicationDbContext> _mockContext;
        private readonly StudentDao _studentDao;
        private readonly List<Student> _studentList;

        public StudentDaoTest()
        {
            _mockSet = new Mock<DbSet<Student>>();
            _mockContext = new Mock<ApplicationDbContext>();

            _studentList = new List<Student>
            {
                new Student { StudentId = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1995, 4, 12), Email = "john.doe@example.com", Phone = "555-1234", Address = "123 Maple Street, Springfield" },
                new Student { StudentId = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1998, 7, 22), Email = "jane.smith@example.com", Phone = "555-5678", Address = "456 Oak Avenue, Springfield" },
                new Student { StudentId = 3, FirstName = "Michael", LastName = "Johnson", DateOfBirth = new DateTime(2000, 2, 18), Email = "michael.johnson@example.com", Phone = "555-9012", Address = "789 Pine Road, Springfield" },
                new Student { StudentId = 4, FirstName = "Emily", LastName = "Davis", DateOfBirth = new DateTime(1999, 11, 5), Email = "emily.davis@example.com", Phone = "555-3456", Address = "101 Birch Lane, Springfield" },
                new Student { StudentId = 5, FirstName = "William", LastName = "Brown", DateOfBirth = new DateTime(1997, 6, 30), Email = "william.brown@example.com", Phone = "555-7890", Address = "202 Cedar Street, Springfield" }
            };

            var data = _studentList.AsQueryable();
            _mockSet.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(data.Provider);
            _mockSet.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(data.Expression);
            _mockSet.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(data.ElementType);
            _mockSet.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            _mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>(ids =>
            {
                var id = (int)ids.First();
                return _studentList.SingleOrDefault(c => c.StudentId == id);
            });

            _mockContext.Setup(c => c.Students).Returns(_mockSet.Object);
            _studentDao = new StudentDao(_mockContext.Object);
        }

        [Fact]
        public void GetAllStudents_ShouldReturnAllStudents()
        {
            var expectedCount = _studentList.Count;
            var result = _studentDao.GetStudents();
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count);
        }

        [Fact]
        public void GetStudentById_ShouldReturnStudent_WhenStudentExists()
        {
            var studentId = 1;
            var result = _studentDao.GetStudentById(studentId);
            Assert.NotNull(result);
            Assert.Equal(studentId, result.StudentId);
            Assert.Equal("John", result.FirstName);
            Assert.Equal("Doe", result.LastName);
            Assert.Equal("john.doe@example.com", result.Email);
        }

        [Fact]
        public void GetStudentById_ShouldReturnNullIfNotFound()
        {
            var studentId = 999;
            var result = _studentDao.GetStudentById(studentId);
            Assert.Null(result);
        }

        [Fact]
        public void AddStudent_ShouldAddStudent()
        {
            var newStudent = new Student
            {
                StudentId = 6,
                FirstName = "Alice",
                LastName = "Cooper",
                DateOfBirth = new DateTime(2001, 8, 30),
                Email = "alice.cooper@example.com",
                Phone = "555-3457",
                Address = "303 Birch Lane, Springfield"
            };
            _studentDao.AddStudent(newStudent);
            _mockSet.Verify(m => m.Add(It.IsAny<Student>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void DeleteStudent_ShouldRemoveStudent()
        {
            var studentToDelete = new Student { StudentId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@gmail.com"};
            _studentDao.DeleteStudent(studentToDelete.StudentId);
            _mockSet.Verify(m => m.Remove(It.Is<Student>(s => s.StudentId == studentToDelete.StudentId)), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}
