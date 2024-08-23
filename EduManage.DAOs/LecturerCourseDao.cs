using EduManage.BusinessObjects.Context;
using EduManage.BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduManage.DAOs;

public class LecturerCourseDao(ApplicationDbContext context)
{
    public List<LecturerCourse> GetLecturerCourses()
    {
        return context.LecturerCourses.Include(l => l.Lecturer)
            .Include(c => c.Course)
            .AsNoTracking()
            .ToList();
    }
    
    public LecturerCourse GetLecturerCourseById(int lecturerId, int courseId)
    {
        return context.LecturerCourses
            .Include(l => l.Lecturer)
            .Include(c => c.Course)
            .AsNoTracking()
            .FirstOrDefault(lc => lc.LecturerId == lecturerId && lc.CourseId == courseId);
    }
    
    public void AddLecturerCourse(LecturerCourse lecturerCourse)
    {
        context.LecturerCourses.Add(lecturerCourse);
        context.SaveChanges();
    }
    
    public void DeleteLecturerCourse(int lecturerId, int courseId)
    {
        var lecturerCourse = context.LecturerCourses.Find(lecturerId, courseId);
        if (lecturerCourse != null) context.LecturerCourses.Remove(lecturerCourse);
        context.SaveChanges();
    }
    
    public void UpdateLecturerCourse(int lecturerId, int courseId, LecturerCourse updatedLecturerCourse)
    {
        // Retrieve the existing entity from the database
        var existingLecturerCourse = context.LecturerCourses
            .FirstOrDefault(lc => lc.LecturerId == lecturerId && lc.CourseId == courseId);
    
        if (existingLecturerCourse == null)
        {
            throw new Exception("LecturerCourse not found");
        }
    
        // Update the fields of the existing entity
        existingLecturerCourse.AssignedDate = updatedLecturerCourse.AssignedDate;
        existingLecturerCourse.Role = updatedLecturerCourse.Role;
    
        // Mark the entity as modified
        context.Entry(existingLecturerCourse).State = EntityState.Modified;
    
        // Save changes to the database
        context.SaveChanges();
    }

    
    public List<LecturerCourse> Find(Func<LecturerCourse, bool> predicate)
    {
        return context.LecturerCourses.Where(predicate).ToList();
    }
}