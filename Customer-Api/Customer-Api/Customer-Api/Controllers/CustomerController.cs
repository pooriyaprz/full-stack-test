using Customer_Domain.Dto;
using Customer_Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CustomerController : ControllerBase
    {
        private protected ICustomerRepository _customerRepository;
        private protected IUnitOfWork _unitOfWork;
        private readonly IValidator<AddCustomerDto> _addCustomerDtoValidator;
        private readonly IValidator<EditeCustomerDto> _editeCustomerDtoValidator;
        public CustomerController(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IValidator<AddCustomerDto> addCustomerDtoValidator, IValidator<EditeCustomerDto> editeCustomerDtoValidator)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _addCustomerDtoValidator = addCustomerDtoValidator;
            _editeCustomerDtoValidator = editeCustomerDtoValidator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddCustomerDto addCustomerDto)
        {
            try
            {
                _addCustomerDtoValidator.ValidateAndThrow(addCustomerDto);
                var customer = await _customerRepository.AddCustomer(addCustomerDto);
                _unitOfWork.Complete();
                return Ok(customer);
            }
            catch (ValidationException ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public async Task<IActionResult> Edite(EditeCustomerDto editeCustomer)
        {
            try
            {
                _editeCustomerDtoValidator.ValidateAndThrow(editeCustomer);
                var customer = await _customerRepository.EditeCustomer(editeCustomer);
                _unitOfWork.Complete();
                return Ok(customer);
            }
            catch (ValidationException ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var customer = await _customerRepository.GetById(id);
            return Ok(customer);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerRepository.GetAll();
            return Ok(customers);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _customerRepository.DeleteCustomer(id);
            return Ok();
        }
    }
}
