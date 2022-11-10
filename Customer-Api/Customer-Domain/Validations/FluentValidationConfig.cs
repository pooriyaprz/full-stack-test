using Customer_Domain.Dto;
using Customer_Domain.Validations.Customer;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Domain.Validations
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidation(this IServiceCollection services)
        {
            services.AddTransient<IValidator<EditeCustomerDto>, EditeCustomerDtoValidator>();
            services.AddTransient<IValidator<AddCustomerDto>, AddCustomerDtoValidator>();
        }
    }
}
