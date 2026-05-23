using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Api.DTOs.Requests;
using Store.Api.DTOs.Responses;
using Store.Api.Entities;
using Store.Api.Models;
using Store.Api.Services.Customers;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{Role.Admin},{Role.Operation}")]
    public class CustomersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomersController(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerRequestDto request)
        {
            var dto = _mapper.Map<Customer>(request);
            var customer = await _customerService.CreateCustomerAsync(dto);
            var response = _mapper.Map<CustomerResponseDto>(customer);

            return CreatedAtAction(nameof(GetCustomerById), new { response.Id }, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerService.GetCustomersAsync();
            var dto = _mapper.Map<List<CustomerResponseDto>>(customers);

            return Ok(dto);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            var dto = _mapper.Map<CustomerResponseDto>(customer);

            return Ok(dto);
        }

        [HttpGet("keyword/{keyword}")]
        public async Task<IActionResult> GetCustomerByKeyword(string keyword)
        {
            var customers = await _customerService.GetCustomerByKeywordAsync(keyword);
            var dto = _mapper.Map<List<CustomerResponseDto>>(customers);

            return Ok(dto);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, UpdateCustomerRequestDto request)
        {
            var dto = _mapper.Map<Customer>(request);
            await _customerService.UpdateCustomerAsync(id, dto);

            return Ok();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _customerService.DeleteCustomerAsync(id);

            return Ok();
        }
    }
}