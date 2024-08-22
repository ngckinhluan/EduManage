using EduManage.BusinessObjects.Entities;
using EduManage.DAOs;
using EduManage.Repositories.Interface;

namespace EduManage.Repositories.Implementation;

public class LecturerRepository(LecturerDao lecturerDao) : ILecturerRepository
{
    public List<Lecturer> GetAll() => lecturerDao.GetLecturers();
    public Lecturer GetById(int id) => lecturerDao.GetLecturerById(id)
    public void Add(Lecturer entity) => lecturerDao.AddLecturer(entity);
    public void Update(int id, Lecturer entity) => lecturerDao.UpdateLecturer(id, entity);
    public void Delete(int id) => lecturerDao.DeleteLecturer(id);
}