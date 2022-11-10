using Customer_Domain.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Domain.Validations.Customer
{
    public class EditeCustomerDtoValidator : AbstractValidator<EditeCustomerDto>
    {
        public EditeCustomerDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress().MaximumLength(256);
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(256);
            RuleFor(x => x.Id).NotNull().MaximumLength(256);
        }
    }
}
