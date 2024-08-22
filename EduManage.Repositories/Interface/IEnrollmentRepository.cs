using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduManage.BusinessObjects.Entities;
using EduManage.Repositories.Interface.GenericRepository;

namespace EduManage.Repositories.Interface
{
    public interface IEnrollmentRepository 
    {
        List<Enrollment> GetAll();
        Enrollment GetById(int studentId, int courseId);
        void Add(Enrollment entity);
        void Update(int studentId, int courseId, Enrollment entity);
        void Delete(int studentId, int courseId);
        void Find (Func<Enrollment, bool> predicate);
    }
}
