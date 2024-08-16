using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduManage.BusinessObjects.DTOs.Request;
using FluentValidation;

namespace EduManage.Validations
{
    public class EnrollmentRequestDtoValidator : AbstractValidator<EnrollmentRequestDto>
    {
        public EnrollmentRequestDtoValidator()
        {
            RuleFor(x => x.Grade)
                .NotEmpty().WithMessage("Grade is required");
        }
    }
}
