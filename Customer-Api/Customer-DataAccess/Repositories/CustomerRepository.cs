using Customer_DataAccess.DataBase;
using Customer_DataAccess.Exeptions;
using Customer_Domain.Customers.Entities;
using Customer_Domain.Dto;
using Customer_Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Customer_DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)

        {
            _context = context;

        }

        public async Task<Customer> AddCustomer(AddCustomerDto customerDto)
        {
            if (await IsCustomerExistsByEmail(customerDto.Email))
            {
                throw new Exception();
            }
            if (customerDto.Email == null || customerDto.Name == null)
            {
                throw new Exception();

            }
            if (customerDto.Email == String.Empty || customerDto.Name == String.Empty)
            {
                throw new Exception();

            }
            var customer = new Customer()
            {
                Name = customerDto.Name,
                Email = customerDto.Email
            };

            await _context.Customers.AddAsync(customer);

            return customer;
        }

        public async Task DeleteCustomer(string id)
        {
            var customer = await GetById(id);
            if (customer == null)
            {
                throw new CustomerNotFindExeption("Customer does not exist!");
            }
            _context.Customers.Remove(customer);


        }

        public async Task<Customer> EditeCustomer(EditeCustomerDto customerDto)
        {
            var customer = await GetById(customerDto.Id);
            if (customer == null)
            {
                throw new CustomerNotFindExeption("Customer does not exist!");
            }
            customer.Email = customerDto.Email;
            customer.Name = customerDto.Name;
            _context.Customers.Update(customer);

            return customer;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(string id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                throw new CustomerNotFindExeption("Customer does not exist!");
            }
            return customer;
        }

        public async Task<bool> IsCustomerExistsByEmail(string email)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Email == email);
            if (customer == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task<bool> IsCustomerExistsById(string id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}
