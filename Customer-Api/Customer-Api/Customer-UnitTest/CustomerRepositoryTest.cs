using Customer_Api.Controllers;
using Customer_DataAccess.DataBase;
using Customer_DataAccess.Repositories;
using Customer_Domain.Customers.Entities;
using Customer_Domain.Dto;
using Customer_Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Customer_UnitTest
{
    public class CustomerRepositoryTest
    {
        private DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "testDb");

        private ApplicationDbContext _context = null;


        private readonly CustomerRepository _repository;
        public CustomerRepositoryTest()
        {
            _context = new ApplicationDbContext(_optionsBuilder.Options);

            _repository = new CustomerRepository(_context);
        }
        [Fact]
        public async void Should_Create_Customer()
        {
            AddCustomerDto addCustomerDto = new AddCustomerDto()
            {
                Email = "pouria@gmail.com",
                Name = "pouria"
            };
            var res = await _repository.AddCustomer(addCustomerDto);
            _context.SaveChanges(true);
            Assert.Equal(res.Email, addCustomerDto.Email);
            Assert.Equal(res.Name, addCustomerDto.Name);
        }
        [Fact]
        public async void Should_Not_Create_Customer()
        {
            AddCustomerDto addCustomerDto = null;

            await Assert.ThrowsAsync<NullReferenceException>(async () => await _repository.AddCustomer(addCustomerDto));
        }
        [Fact]
        public async void Name_Should_Not_Be_Null()
        {
            AddCustomerDto addCustomerDto = new AddCustomerDto()
            {
                Email = "tesr@gmail.com",
                Name = null
            };

            await Assert.ThrowsAsync<Exception>(async () => await _repository.AddCustomer(addCustomerDto));
        }
        [Fact]
        public async void Email_Should_Not_Be_Null()
        {
            AddCustomerDto addCustomerDto = new AddCustomerDto()
            {
                Email = null,
                Name = "test"
            };

            await Assert.ThrowsAsync<Exception>(async () => await _repository.AddCustomer(addCustomerDto));
        }
        [Fact]
        public async void Email_And_Name_Should_Not_Be_Null()
        {
            AddCustomerDto addCustomerDto = new AddCustomerDto()
            {
                Email = null,
                Name = null
            };

            await Assert.ThrowsAsync<Exception>(async () => await _repository.AddCustomer(addCustomerDto));
        }
        [Fact]
        public async void Email_Should_Not_Be_Empty()
        {
            AddCustomerDto addCustomerDto = new AddCustomerDto()
            {
                Email = "",
                Name = "test"
            };

            await Assert.ThrowsAsync<Exception>(async () => await _repository.AddCustomer(addCustomerDto));
        }
        [Fact]
        public async void Name_Should_Not_Be_Empty()
        {
            AddCustomerDto addCustomerDto = new AddCustomerDto()
            {
                Email = "test@gmail.com",
                Name = ""
            };

            await Assert.ThrowsAsync<Exception>(async () => await _repository.AddCustomer(addCustomerDto));
        }
        [Fact]
        public async void Email_And_Name_Should_Not_Be_Empty()
        {
            AddCustomerDto addCustomerDto = new AddCustomerDto()
            {
                Email = "",
                Name = ""
            };

            await Assert.ThrowsAsync<Exception>(async () => await _repository.AddCustomer(addCustomerDto));
        }
        [Fact]
        public async void Should_Return_Customer()
        {
            Customer addCustomer = new Customer()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "pouria@gmail.com",
                Name = "pouria"
            };
            _context.Customers.Add(addCustomer);
            _context.SaveChanges();

            var res = await _repository.GetById(addCustomer.Id);

            Assert.Equal(res.Email, addCustomer.Email);
            Assert.Equal(res.Name, addCustomer.Name);

        }
        [Fact]
        public async void Should_Edite_Customer()
        {
            Customer addCustomer = new Customer()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "pouria@gmail.com",
                Name = "pouria"
            };
            _context.Customers.Add(addCustomer);
            _context.SaveChanges();


            var editeCustomer = new EditeCustomerDto()
            {
                Id = addCustomer.Id,
                Email = "test@gmail.com",
                Name = "test"
            };


            var res = await _repository.EditeCustomer(editeCustomer);
            _context.SaveChanges(true);
            Assert.Equal(res.Email, editeCustomer.Email);
            Assert.Equal(res.Name, editeCustomer.Name);

        }

        [Fact]
        public async void Should_Delete_Customer()
        {
            Customer addCustomer = new Customer()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "pouria@gmail.com",
                Name = "pouria"
            };
            _context.Customers.Add(addCustomer);
            _context.SaveChanges();
            await _repository.DeleteCustomer(addCustomer.Id);
            _context.SaveChanges(true);
            var res = _context.Customers.Find(addCustomer.Id);
            Assert.Null(res);

        }
    }
}