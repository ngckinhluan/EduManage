using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.Repositories.Interface;
using FluentValidation;

namespace EduManage.Validations
{
    public class StudentRequestDtoValidator : AbstractValidator<StudentRequestDto>
    {
        private readonly IStudentRepository _studentRepository;

        public StudentRequestDtoValidator(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            RuleFor(x => x.FirstName)
                .MaximumLength(255).WithMessage("First name cannot exceed 255 characters")
                .NotEmpty().WithMessage("First name is required");
            RuleFor(x => x.LastName)
                .MaximumLength(255).WithMessage("Last name cannot exceed 255 characters")
                .NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.Email)
                .MaximumLength(255).WithMessage("Email cannot exceed 255 characters")
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("A valid email is required!")
                .Must(BeUniqueEmail).WithMessage("Email already exists");

        }
        private bool BeUniqueEmail(string email)
        {
            return _studentRepository.GetStudentByEmail(email) == null;
        }
    }
}
