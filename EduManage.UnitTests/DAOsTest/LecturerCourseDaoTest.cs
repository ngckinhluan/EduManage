using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using EduManage.BusinessObjects.Context;
using EduManage.BusinessObjects.Entities;
using EduManage.DAOs;

public class LecturerCourseDaoTests
{
    private readonly Mock<ApplicationDbContext> _mockContext;
    private readonly Mock<DbSet<LecturerCourse>> _mockSet;
    private readonly LecturerCourseDao _dao;

    public LecturerCourseDaoTests()
    {
        _mockContext = new Mock<ApplicationDbContext>();
        _mockSet = new Mock<DbSet<LecturerCourse>>();
        _dao = new LecturerCourseDao(_mockContext.Object);
    }

    [Fact]
    public void GetLecturerCourses_ReturnsAllLecturerCourses()
    {
        // Arrange
        var lecturerCourses = new List<LecturerCourse>
        {
            new LecturerCourse { LecturerId = 1, CourseId = 1 },
            new LecturerCourse { LecturerId = 2, CourseId = 2 }
        }.AsQueryable();

        _mockSet.As<IQueryable<LecturerCourse>>().Setup(m => m.Provider).Returns(lecturerCourses.Provider);
        _mockSet.As<IQueryable<LecturerCourse>>().Setup(m => m.Expression).Returns(lecturerCourses.Expression);
        _mockSet.As<IQueryable<LecturerCourse>>().Setup(m => m.ElementType).Returns(lecturerCourses.ElementType);
        _mockSet.As<IQueryable<LecturerCourse>>().Setup(m => m.GetEnumerator()).Returns(lecturerCourses.GetEnumerator());

        _mockContext.Setup(c => c.LecturerCourses).Returns(_mockSet.Object);

        // Act
        var result = _dao.GetLecturerCourses();

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void GetLecturerCourseById_ReturnsCorrectLecturerCourse()
    {
        // Arrange
        var lecturerCourses = new List<LecturerCourse>
        {
            new LecturerCourse { LecturerId = 1, CourseId = 1 },
            new LecturerCourse { LecturerId = 2, CourseId = 2 }
        }.AsQueryable();

        _mockSet.As<IQueryable<LecturerCourse>>().Setup(m => m.Provider).Returns(lecturerCourses.Provider);
        _mockSet.As<IQueryable<LecturerCourse>>().Setup(m => m.Expression).Returns(lecturerCourses.Expression);
        _mockSet.As<IQueryable<LecturerCourse>>().Setup(m => m.ElementType).Returns(lecturerCourses.ElementType);
        _mockSet.As<IQueryable<LecturerCourse>>().Setup(m => m.GetEnumerator()).Returns(lecturerCourses.GetEnumerator());

        _mockContext.Setup(c => c.LecturerCourses).Returns(_mockSet.Object);

        // Act
        var result = _dao.GetLecturerCourseById(1, 1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.LecturerId);
        Assert.Equal(1, result.CourseId);
    }

    [Fact]
    public void AddLecturerCourse_AddsLecturerCourse()
    {
        // Arrange
        var lecturerCourse = new LecturerCourse { LecturerId = 1, CourseId = 1 };

        _mockContext.Setup(c => c.LecturerCourses).Returns(_mockSet.Object);

        // Act
        _dao.AddLecturerCourse(lecturerCourse);

        // Assert
        _mockSet.Verify(m => m.Add(It.IsAny<LecturerCourse>()), Times.Once());
        _mockContext.Verify(c => c.SaveChanges(), Times.Once());
    }

    [Fact]
    public void DeleteLecturerCourse_DeletesLecturerCourse()
    {
        // Arrange
        var lecturerCourse = new LecturerCourse { LecturerId = 1, CourseId = 1 };
        _mockSet.Setup(m => m.Find(It.IsAny<int>(), It.IsAny<int>())).Returns(lecturerCourse);
        _mockContext.Setup(c => c.LecturerCourses).Returns(_mockSet.Object);

        // Act
        _dao.DeleteLecturerCourse(1, 1);

        // Assert
        _mockSet.Verify(m => m.Remove(It.IsAny<LecturerCourse>()), Times.Once());
        _mockContext.Verify(c => c.SaveChanges(), Times.Once());
    }

    // [Fact]
    // public void UpdateLecturerCourse_UpdatesLecturerCourse()
    // {
    //     // Arrange
    //     var lecturerCourse = new LecturerCourse { LecturerId = 1, CourseId = 1, Role = "Instructor" };
    //     var lecturerCourses = new List<LecturerCourse> { lecturerCourse }.AsQueryable();
    //
    //     _mockSet.As<IQueryable<LecturerCourse>>().Setup(m => m.Provider).Returns(lecturerCourses.Provider);
    //     _mockSet.As<IQueryable<LecturerCourse>>().Setup(m => m.Expression).Returns(lecturerCourses.Expression);
    //     _mockSet.As<IQueryable<LecturerCourse>>().Setup(m => m.ElementType).Returns(lecturerCourses.ElementType);
    //     _mockSet.As<IQueryable<LecturerCourse>>().Setup(m => m.GetEnumerator()).Returns(lecturerCourses.GetEnumerator());
    //     _mockContext.Setup(c => c.LecturerCourses).Returns(_mockSet.Object);
    //     var updatedLecturerCourse = new LecturerCourse { LecturerId = 1, CourseId = 1, Role = "Professor" };
    //
    //     // Act
    //     _dao.UpdateLecturerCourse(1, 1, updatedLecturerCourse);
    //
    //     // Assert
    //     _mockSet.Verify(m => m.Update(It.Is<LecturerCourse>(lc => lc.Role == "Professor")), Times.Once());
    //     _mockContext.Verify(c => c.SaveChanges(), Times.Once());
    // }
}