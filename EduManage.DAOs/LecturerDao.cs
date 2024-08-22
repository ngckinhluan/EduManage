using EduManage.BusinessObjects.Context;
using EduManage.BusinessObjects.Entities;

namespace EduManage.DAOs;

public class LecturerDao(ApplicationDbContext context)
{
    public List<Lecturer> GetLecturers()
    {
        return context.Lecturers.ToList();
    }
    
    public Lecturer? GetLecturerById(int lecturerId)
    {
        return context.Lecturers.Find(lecturerId);
    }
    
    public void AddLecturer(Lecturer lecturer)
    {
        context.Lecturers.Add(lecturer);
        context.SaveChanges();
    }
    
    public void DeleteLecturer(int lecturerId)
    {
        var lecturer = context.Lecturers.Find(lecturerId);
        if (lecturer != null) context.Lecturers.Remove(lecturer);
        context.SaveChanges();
    }
    
    public void UpdateLecturer(int id, Lecturer lecturer)
    {
        var existingLecturer = context.Lecturers.Find(id);
        if (existingLecturer == null)
        {
            throw new Exception("Lecturer not found");
        }
        existingLecturer.UserName = lecturer.UserName;
        existingLecturer.FirstName = lecturer.FirstName;
        existingLecturer.LastName = lecturer.LastName;
        existingLecturer.Email = lecturer.Email;
        existingLecturer.Phone = lecturer.Phone;
        existingLecturer.Password = lecturer.Password;
        existingLecturer.Address = lecturer.Address;
        context.Lecturers.Update(lecturer);
        context.SaveChanges();
    }
    
    public List<Lecturer> Find(Func<Lecturer, bool> predicate)
    {
        return context.Lecturers.Where(predicate).ToList();
    }
    
    
 
    
    
}