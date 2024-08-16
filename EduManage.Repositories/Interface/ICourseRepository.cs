using EduManage.Repositories.Interface.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduManage.BusinessObjects.Entities;

namespace EduManage.Repositories.Interface
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
    }
}
