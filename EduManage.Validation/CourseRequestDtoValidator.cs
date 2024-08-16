using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.Repositories.Interface;

namespace EduManage.Validations
{
    public class CourseRequestDtoValidator : AbstractValidator<CourseRequestDto>
    {
        private readonly ICourseRepository _repository;
        public CourseRequestDtoValidator(ICourseRepository repository)
        {
            _repository = repository;
            RuleFor(x => x.CourseName)
                .MaximumLength(255).WithMessage("Course name cannot exceed 255 characters")
                .NotEmpty().WithMessage("Course name is required");
            RuleFor(x => x.Description)
                .MaximumLength(255).WithMessage("Description cannot exceed 255 characters")
                .NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.InstructorName)
                .MaximumLength(255).WithMessage("Instructor name cannot exceed 255 characters")
                .NotEmpty().WithMessage("Instructor name is required");
            RuleFor(x => x.Credit)
                .NotEmpty().WithMessage("Credit is required")
                .GreaterThan(0).WithMessage("Credit must be greater than 0");

        }
    }
}
