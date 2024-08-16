using EduManage.BusinessObjects.Entities;
using EduManage.Repositories.Interface.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduManage.Repositories.Interface
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Student GetStudentByEmail(string email);
    }
}
