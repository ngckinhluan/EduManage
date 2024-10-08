﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.Entities;
using EduManage.Repositories.Interface;
using EduManage.Services.Interface;

namespace EduManage.Services.Implementation
{
    public class StudentService(IStudentRepository repository, IMapper mapper) : IStudentService
    {
        public List<Student> GetAll() => repository.GetAll();
        public Student GetById(int id) => repository.GetById(id);
        public void Add(StudentRequestDto student) => repository.Add(mapper.Map<Student>(student));
        public void Update(int id, StudentRequestDto student) => repository.Update(id, mapper.Map<Student>(student));
        public void Delete(int id) => repository.Delete(id);
        public List<Student> Find(Func<Student, bool> predicate) => repository.Find(predicate);
    }
}