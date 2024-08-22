using EduManage.BusinessObjects.Entities;
using EduManage.Repositories.Interface;

namespace EduManage.Repositories.Implementation;

public class LecturerCourseRepository : ILecturerRepository
{
    public List<Lecturer> GetAll()
    {
        throw new NotImplementedException();
    }

    public Lecturer GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Add(Lecturer entity)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, Lecturer entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Lecturer> Find(Func<Lecturer, bool> predicate)
    {
        throw new NotImplementedException();
    }
}