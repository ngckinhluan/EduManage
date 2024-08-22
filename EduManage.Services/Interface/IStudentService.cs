using EduManage.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduManage.BusinessObjects.DTOs.Request;

namespace EduManage.Services.Interface
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student GetById(int id);
        void Add(StudentRequestDto student);
        void Update(int id, StudentRequestDto student);
        void Delete(int id);
        List<Student> Find(Func<Student, bool> predicate);
    }
}