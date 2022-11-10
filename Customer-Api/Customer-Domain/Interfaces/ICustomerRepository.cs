using Customer_Domain.Customers.Entities;
using Customer_Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetById(string id);
        Task<List<Customer>> GetAll();
        Task<Customer> AddCustomer(AddCustomerDto customerDto);
        Task<Customer> EditeCustomer(EditeCustomerDto customerDto);
        Task DeleteCustomer(string id);
        Task<bool> IsCustomerExistsByEmail(string email);
        Task<bool> IsCustomerExistsById(string email);
    }
}
