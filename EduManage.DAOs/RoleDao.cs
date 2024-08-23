using EduManage.BusinessObjects.Context;
using EduManage.BusinessObjects.Entities;

namespace EduManage.DAOs;

public class RoleDao(ApplicationDbContext context)
{
    public List<Role> GetRoles()
    {
        return context.Roles.ToList();
    }

    public Role GetRoleById(int roleId)
    {
        return context.Roles.Find(roleId);
    }

    public void AddRole(Role role)
    {
        context.Roles.Add(role);
        context.SaveChanges();
    }

    public void UpdateRole(int id, Role role)
    {
        var existingRole = context.Roles.Find(id);
        if (existingRole == null)
        {
            throw new Exception("Role not found");
        }
        existingRole.RoleName = role.RoleName;
        existingRole.Description = role.Description;
        context.Roles.Update(role);
        context.SaveChanges();
    }

    public void DeleteRole(int roleId)
    {
        var role = context.Roles.Find(roleId);
        context.Roles.Remove(role);
        context.SaveChanges();
    }
}