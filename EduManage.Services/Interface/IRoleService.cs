using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.Entities;

namespace EduManage.Services.Interface;

public interface IRoleService
{
    List<Role> GetAll();
    Role GetById(int id);
    void Add(RoleRequestDto entity);
    void Update(int id, RoleRequestDto entity);
    void Delete(int id);
}