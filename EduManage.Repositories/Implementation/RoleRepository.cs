using EduManage.BusinessObjects.Entities;
using EduManage.DAOs;
using EduManage.Repositories.Interface;

namespace EduManage.Repositories.Implementation;

public class RoleRepository(RoleDao roleDao) : IRoleRepository
{
    public List<Role> GetAll()
    {
        return roleDao.GetRoles();
    }

    public Role GetById(int id)
    {
        return roleDao.GetRoleById(id);
    }

    public void Add(Role entity)
    {
        roleDao.AddRole(entity);
    }

    public void Update(int id, Role entity)
    {
        roleDao.UpdateRole(id, entity);
    }

    public void Delete(int id)
    {
        roleDao.DeleteRole(id);
    }

    public List<Role> Find(Func<Role, bool> predicate)
    {
        return roleDao.GetRoles().Where(predicate).ToList();
    }
}