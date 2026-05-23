using Microsoft.EntityFrameworkCore;
using Store.Api.Entities;
using Store.Api.Exceptions;

namespace Store.Api.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<OrderService> _logger;

        public OrderService(AppDbContext context, ILogger<OrderService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _logger.LogInformation("Creating new order for CustomerId: {CustomerId}", order.CustomerId);

            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();

            _logger.LogInformation("Order created successfully. OrderId: {OrderId}", order.Id);

            return order;
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            _logger.LogInformation("Deleting order. OrderId: {OrderId}", id);

            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                _logger.LogWarning("Delete failed. Order not found. OrderId: {OrderId}", id);

                throw new NotFoundException("Invalid order id, Order not found");
            }

            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();

            _logger.LogInformation("Order deleted successfully. OrderId: {OrderId}", id);
        }

        public async Task<Order> GetOrderByCustomerIdAsycn(Guid customerId)
        {
            _logger.LogInformation("Retrieving order by CustomerId: {CustomerId}", customerId);

            var order = await _context.Orders
                .AsNoTracking()
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.CustomerId == customerId);

            if (order == null)
            {
                _logger.LogWarning("Order not found for CustomerId: {CustomerId}", customerId);

                throw new NotFoundException("Order not found");
            }

            return order;
        }

        public async Task<List<Order>> GetOrderByDatetimeAsync(DateTime startDate, DateTime endDate)
        {
            _logger.LogInformation("Retrieving orders between {StartDate} and {EndDate}", startDate, endDate);

            var orders = await _context.Orders
                .AsNoTracking()
                .Include(o => o.OrderDetails)
                .Where(o =>
                    o.CreatedAt >= startDate &&
                    o.CreatedAt <= endDate)
                .ToListAsync();

            _logger.LogInformation("Retrieved {Count} orders", orders.Count);

            return orders;
        }

        public async Task<Order> GetOrderByIdAsync(Guid id)
        {
            _logger.LogInformation("Retrieving order. OrderId: {OrderId}", id);

            var order = await _context.Orders
                .AsNoTracking()
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                _logger.LogWarning("Order not found. OrderId: {OrderId}", id);

                throw new NotFoundException("Invalid order id, Order not found");
            }

            return order;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            _logger.LogInformation("Retrieving all orders");

            var orders = await _context.Orders
                .AsNoTracking()
                .Include(o => o.OrderDetails)
                .ToListAsync();

            _logger.LogInformation("Retrieved {Count} orders", orders.Count);

            return orders;
        }

        public async Task UpdateOrderAsync(Guid id, Order updatedOrder)
        {
            _logger.LogInformation("Updating order. OrderId: {OrderId}", id);

            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                _logger.LogWarning("Update failed. Order not found. OrderId: {OrderId}", id);

                throw new NotFoundException("Invalid order id, Order not found");
            }

            order.CustomerId = updatedOrder.CustomerId;
            order.OrderDetails = updatedOrder.OrderDetails;

            await _context.SaveChangesAsync();

            _logger.LogInformation("Order updated successfully. OrderId: {OrderId}", id);
        }
    }
}