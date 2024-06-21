using FluentValidation;
using managementtaskexercice.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace managementtaskexercice.Application.Validators
{
    public class ParameterPagingValidator:AbstractValidator<ParametersOfPaging>
    {
        public ParameterPagingValidator() { 

           RuleFor(p=>p.PageNumber).GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must greater than 1");
           RuleFor(p=>p.NumberOfTasks).GreaterThanOrEqualTo(1).WithMessage("{PropertyName}  must greater than 1");
        }
    }
}
