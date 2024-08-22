using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.Entities;

namespace EduManage.Services.Interface;

public interface ILecturerService
{
    List<Lecturer> GetAll();
    Lecturer GetById(int id);
    void Add(LecturerRequestDto entity);
    void Update(int id, LecturerRequestDto entity);
    void Delete(int id);
    List<Lecturer> Find(Func<Lecturer, bool> predicate);
}