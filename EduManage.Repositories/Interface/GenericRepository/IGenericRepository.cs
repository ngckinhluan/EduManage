using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduManage.Repositories.Interface.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        List<T> Find(Func<T, bool> predicate);
    }
}
