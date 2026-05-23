using Store.Api.Entities;

namespace Store.Api.Services.Orders
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);

        Task<List<Order>> GetOrdersAsync();

        Task<Order?> GetOrderByIdAsync(Guid id);

        Task<Order?> GetOrderByCustomerIdAsycn(Guid id);

        Task<List<Order>> GetOrderByDatetimeAsync(DateTime startDate, DateTime endDate);

        Task UpdateOrderAsync(Guid id, Order updatedOrder);

        Task DeleteOrderAsync(Guid id);
    }
}