using Store.Api.Entities;

namespace Store.Api.Services.Customers
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(Customer customer);

        Task<Customer> GetCustomerByIdAsync(Guid id);

        Task<List<Customer>> GetCustomerByKeywordAsync(string keyword);

        Task<List<Customer>> GetCustomersAsync();

        Task UpdateCustomerAsync(Guid id, Customer updatedCustomer);

        Task DeleteCustomerAsync(Guid id);
    }
}