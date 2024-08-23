using AutoMapper;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.Entities;
using EduManage.Repositories.Interface;
using EduManage.Services.Interface;

namespace EduManage.Services.Implementation;

public class LecturerService(ILecturerRepository repository, IMapper mapper) : ILecturerService
{
    public List<Lecturer> GetAll() => repository.GetAll();
    public Lecturer GetById(int id) => repository.GetById(id);
    public void Add(LecturerRequestDto entity) => repository.Add(mapper.Map<Lecturer>(entity));
    public void Update(int id, LecturerRequestDto entity) => repository.Update(id, mapper.Map<Lecturer>(entity));
    public void Delete(int id) => repository.Delete(id);
    public List<Lecturer> Find(Func<Lecturer, bool> predicate) => repository.Find(predicate);
}