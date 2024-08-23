using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using EduManage.BusinessObjects.Context;
using EduManage.BusinessObjects.Entities;
using EduManage.DAOs;

public class EnrollmentDaoTests
{
    private readonly Mock<ApplicationDbContext> _mockContext;
    private readonly Mock<DbSet<Enrollment>> _mockSet;
    private readonly EnrollmentDao _dao;

    public EnrollmentDaoTests()
    {
        _mockContext = new Mock<ApplicationDbContext>();
        _mockSet = new Mock<DbSet<Enrollment>>();
        _dao = new EnrollmentDao(_mockContext.Object);
    }

    [Fact]
    public void GetEnrollments_ReturnsAllEnrollments()
    {
        // Arrange
        var enrollments = new List<Enrollment>
        {
            new Enrollment { StudentId = 1, CourseId = 1 },
            new Enrollment { StudentId = 2, CourseId = 2 }
        }.AsQueryable();

        _mockSet.As<IQueryable<Enrollment>>().Setup(m => m.Provider).Returns(enrollments.Provider);
        _mockSet.As<IQueryable<Enrollment>>().Setup(m => m.Expression).Returns(enrollments.Expression);
        _mockSet.As<IQueryable<Enrollment>>().Setup(m => m.ElementType).Returns(enrollments.ElementType);
        _mockSet.As<IQueryable<Enrollment>>().Setup(m => m.GetEnumerator()).Returns(enrollments.GetEnumerator());

        _mockContext.Setup(c => c.Enrollments).Returns(_mockSet.Object);

        // Act
        var result = _dao.GetEnrollments();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(1, result[0].StudentId);
        Assert.Equal(2, result[1].StudentId);
    }

    [Fact]
    public void GetEnrollmentById_ReturnsCorrectEnrollment()
    {
        // Arrange
        var enrollments = new List<Enrollment>
        {
            new Enrollment { StudentId = 1, CourseId = 1 },
            new Enrollment { StudentId = 2, CourseId = 2 }
        }.AsQueryable();

        _mockSet.As<IQueryable<Enrollment>>().Setup(m => m.Provider).Returns(enrollments.Provider);
        _mockSet.As<IQueryable<Enrollment>>().Setup(m => m.Expression).Returns(enrollments.Expression);
        _mockSet.As<IQueryable<Enrollment>>().Setup(m => m.ElementType).Returns(enrollments.ElementType);
        _mockSet.As<IQueryable<Enrollment>>().Setup(m => m.GetEnumerator()).Returns(enrollments.GetEnumerator());

        _mockContext.Setup(c => c.Enrollments).Returns(_mockSet.Object);

        // Act
        var result = _dao.GetEnrollmentById(1, 1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.StudentId);
        Assert.Equal(1, result.CourseId);
    }
    
    

    [Fact]
    public void AddEnrollment_AddsEnrollment()
    {
        // Arrange
        var enrollment = new Enrollment { StudentId = 1, CourseId = 1 };

        _mockContext.Setup(c => c.Enrollments).Returns(_mockSet.Object);

        // Act
        _dao.AddEnrollment(enrollment);

        // Assert
        _mockSet.Verify(m => m.Add(It.IsAny<Enrollment>()), Times.Once());
        _mockContext.Verify(c => c.SaveChanges(), Times.Once());
    }
    
    [Fact]
    public void UpdateEnrollment_UpdatesEnrollment()
    {
        // Arrange
        var enrollment = new Enrollment { StudentId = 1, CourseId = 1, Grade = "B" };
        var enrollments = new List<Enrollment> { enrollment }.AsQueryable();

        _mockSet.As<IQueryable<Enrollment>>().Setup(m => m.Provider).Returns(enrollments.Provider);
        _mockSet.As<IQueryable<Enrollment>>().Setup(m => m.Expression).Returns(enrollments.Expression);
        _mockSet.As<IQueryable<Enrollment>>().Setup(m => m.ElementType).Returns(enrollments.ElementType);
        _mockSet.As<IQueryable<Enrollment>>().Setup(m => m.GetEnumerator()).Returns(enrollments.GetEnumerator());

        _mockContext.Setup(c => c.Enrollments).Returns(_mockSet.Object);

        var updatedEnrollment = new Enrollment { StudentId = 1, CourseId = 1, Grade = "A" };

        // Act
        _dao.UpdateEnrollment(1, 1, updatedEnrollment);

        // Assert
        Assert.Equal("A", enrollment.Grade);
        _mockContext.Verify(c => c.SaveChanges(), Times.Once());
    }

    [Fact]
    public void DeleteEnrollment_DeletesEnrollment()
    {
        // Arrange
        var enrollment = new Enrollment { StudentId = 1, CourseId = 1 };
        _mockSet.Setup(m => m.Find(It.IsAny<int>(), It.IsAny<int>())).Returns(enrollment);
        _mockContext.Setup(c => c.Enrollments).Returns(_mockSet.Object);

        // Act
        _dao.DeleteEnrollment(1, 1);

        // Assert
        _mockSet.Verify(m => m.Remove(It.IsAny<Enrollment>()), Times.Once());
        _mockContext.Verify(c => c.SaveChanges(), Times.Once());
    }

    [Fact]
    public void Find_ReturnsMatchingEnrollments()
    {
        // Arrange
        var enrollments = new List<Enrollment>
        {
            new Enrollment { StudentId = 1, CourseId = 1, Grade = "A" },
            new Enrollment { StudentId = 2, CourseId = 2, Grade = "B" }
        }.AsQueryable();

        _mockSet.As<IQueryable<Enrollment>>().Setup(m => m.Provider).Returns(enrollments.Provider);
        _mockSet.As<IQueryable<Enrollment>>().Setup(m => m.Expression).Returns(enrollments.Expression);
        _mockSet.As<IQueryable<Enrollment>>().Setup(m => m.ElementType).Returns(enrollments.ElementType);
        _mockSet.As<IQueryable<Enrollment>>().Setup(m => m.GetEnumerator()).Returns(enrollments.GetEnumerator());

        _mockContext.Setup(c => c.Enrollments).Returns(_mockSet.Object);

        // Act
        var result = _dao.Find(e => e.Grade == "A");

        // Assert
        Assert.Single(result);
        Assert.Equal("A", result.First().Grade);
    }
}
