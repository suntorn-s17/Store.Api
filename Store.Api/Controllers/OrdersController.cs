using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Api.DTOs.Requests;
using Store.Api.DTOs.Responses;
using Store.Api.Entities;
using Store.Api.Models;
using Store.Api.Services.Orders;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{Role.Admin},{Role.Operation}")]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrdersController(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequestDto request)
        {
            var dto = _mapper.Map<Order>(request);
            var order = await _orderService.CreateOrderAsync(dto);
            var response = _mapper.Map<OrderResponseDto>(dto);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrdersAsync();

            var response = _mapper.Map<List<OrderResponseDto>>(orders);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            var response = _mapper.Map<OrderResponseDto>(order);
            return Ok(response);
        }

        [HttpGet("search/{customerId}")]
        public async Task<IActionResult> GetOrderByCustomerId(Guid customerId)
        {
            var order = await _orderService.GetOrderByCustomerIdAsycn(customerId);
            var response = _mapper.Map<OrderResponseDto>(order);
            return Ok(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetOrderByDate(DateTime startDate, DateTime endDate)
        {
            var orders = await _orderService.GetOrderByDatetimeAsync(startDate, endDate);
            var response = _mapper.Map<List<OrderResponseDto>>(orders);
            return Ok(response);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, UpdateOrderRequestDto request)
        {
            var dto = _mapper.Map<Order>(request);
            await _orderService.UpdateOrderAsync(id, dto);
            return Ok();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await _orderService.DeleteOrderAsync(id);
            return Ok();
        }
    }
}