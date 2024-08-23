using AutoMapper;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.Entities;
using EduManage.Repositories.Interface;
using EduManage.Services.Interface;

namespace EduManage.Services.Implementation;

public class RoleService(IRoleRepository roleRepository, IMapper mapper) : IRoleService
{
    public List<Role> GetAll()
    {
        return roleRepository.GetAll();
    }

    public Role GetById(int id)
    {
        return roleRepository.GetById(id);
    }

    public void Add(RoleRequestDto entity)
    {
        roleRepository.Add(mapper.Map<Role>(entity));
    }

    public void Update(int id, RoleRequestDto entity)
    {
        roleRepository.Update(id, mapper.Map<Role>(entity));
    }

    public void Delete(int id)
    {
        roleRepository.Delete(id);
    }
}