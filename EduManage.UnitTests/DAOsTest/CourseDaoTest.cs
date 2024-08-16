using EduManage.BusinessObjects.Context;
using EduManage.BusinessObjects.Entities;
using EduManage.DAOs;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EduManage.UnitTesting.DAOsTest
{
    public class CourseDaoTest
    {
        private readonly Mock<DbSet<Course>> _mockSet;
        private readonly Mock<ApplicationDbContext> _mockContext;
        private readonly CourseDao _courseDao;
        private readonly List<Course> _courseList;

        public CourseDaoTest()
        {
            _mockSet = new Mock<DbSet<Course>>();
            _mockContext = new Mock<ApplicationDbContext>();
            _courseList = new List<Course>
            {
                new Course { CourseId = 1, CourseName = "Math 101", Description = "Basic Mathematics", Credit = 3, InstructorName = "Dr. Smith" },
                new Course { CourseId = 2, CourseName = "Physics 101", Description = "Introduction to Physics", Credit = 4, InstructorName = "Dr. Johnson" },
                new Course { CourseId = 3, CourseName = "Chemistry 101", Description = "Basic Chemistry", Credit = 3, InstructorName = "Dr. Lee" }
            };

            var data = _courseList.AsQueryable();
            _mockSet.As<IQueryable<Course>>().Setup(m => m.Provider).Returns(data.Provider);
            _mockSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(data.Expression);
            _mockSet.As<IQueryable<Course>>().Setup(m => m.ElementType).Returns(data.ElementType);
            _mockSet.As<IQueryable<Course>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            _mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>(ids =>
            {
                var id = (int)ids.First();
                return _courseList.SingleOrDefault(c => c.CourseId == id);
            });
            _mockContext.Setup(c => c.Courses).Returns(_mockSet.Object);
            _courseDao = new CourseDao(_mockContext.Object);
        }


        [Fact]
        public void GetCourses_ShouldReturnAllCourses()
        {
            var result = _courseDao.GetCourses();
            Assert.NotNull(result);
            Assert.Equal(_courseList.Count, result.Count);
        }

        [Fact]
        public void GetCourseById_ShouldReturnCourse_WhenCourseExists()
        {
            var result = _courseDao.GetCourseById(1);
            Assert.NotNull(result);
            Assert.Equal(1, result.CourseId);
            Assert.Equal("Math 101", result.CourseName);
        }

        [Fact]
        public void GetCourseById_ShouldReturnNull_WhenCourseDoesNotExist()
        {
            var result = _courseDao.GetCourseById(999);
            Assert.Null(result);
        }

        [Fact]
        public void AddCourse_ShouldAddCourse()
        {
            var newCourse = new Course { CourseId = 4, CourseName = "Biology 101", Description = "Introduction to Biology", Credit = 3, InstructorName = "Dr. Green" };

            _courseDao.AddCourse(newCourse);
            _mockSet.Verify(m => m.Add(It.IsAny<Course>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void DeleteCourse_ShouldRemoveCourse()
        {
            var courseToDelete = _courseList.First();
            _courseDao.DeleteCourse(courseToDelete.CourseId);
            _mockSet.Verify(m => m.Remove(It.IsAny<Course>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void UpdateCourse_ShouldUpdateCourse()
        {
            var existingCourse = _courseDao.GetCourseById(1);
            var updatedCourse = new Course { CourseId = existingCourse.CourseId, CourseName = "Math 102", Description = "Advanced Mathematics", Credit = 4, InstructorName = "Dr. Smith" };
            _courseDao.UpdateCourse(existingCourse.CourseId, updatedCourse);
            _mockSet.Verify(m => m.Update(It.IsAny<Course>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}
