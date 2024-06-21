using FluentValidation;
using managementtaskexercice.Application.Models;
using managementtaskexercice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Application.Validators
{
    public  class MTaskValidator:AbstractValidator<MTaskDto>
    {
        public MTaskValidator() {


            RuleFor(t => t.Title).NotEmpty()
                 .WithMessage("{PropertyName} is required .")
                 .NotNull()
                 .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 charaters");

            RuleFor(t => t.Description).NotEmpty()
                .WithMessage("{PropertyName} is required .")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250");

            RuleFor(t => t.DueDate)
                .NotEmpty().WithMessage("{PropertyName} is required .")
                .NotNull();


            RuleFor(t => t.Priority).NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(0)
                .WithMessage("PropertyName} must greater than 0");

            RuleFor(t => t.Status).NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .Must(BeAValidStatus).
                WithMessage("status  must be Pending,InProgress or Completed.");

        }
        public bool BeAValidStatus(string status)
        {
            Status result;
            return Enum.TryParse(status, out result) && Enum.IsDefined(typeof(Status), result);
        }
    }
}
