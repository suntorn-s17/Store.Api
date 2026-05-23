using Microsoft.EntityFrameworkCore;
using Store.Api.Entities;
using Store.Api.Exceptions;

namespace Store.Api.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(AppDbContext context, ILogger<CustomerService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _logger.LogInformation("Creating customer: {CustomerName}", customer.CustomerName);

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Customer created successfully. CustomerId: {CustomerId}", customer.Id);

            return customer;
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            _logger.LogInformation("Deleting customer. CustomerId: {CustomerId}", id);

            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                _logger.LogWarning("Delete failed. Customer not found. CustomerId: {CustomerId}", id);

                throw new NotFoundException("Invalid customer id, Customer not found");
            }

            _context.Remove(customer);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Customer deleted successfully. CustomerId: {CustomerId}", id);
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            _logger.LogInformation("Retrieving customer. CustomerId: {CustomerId}", id);

            var customer = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                _logger.LogWarning("Customer not found. CustomerId: {CustomerId}", id);

                throw new NotFoundException("Invalid customer id, Customer not found");
            }

            _logger.LogInformation("Customer found. CustomerId: {CustomerId}", id);

            return customer;
        }

        public async Task<List<Customer>> GetCustomerByKeywordAsync(string keyword)
        {
            _logger.LogInformation("Searching customers by keyword");

            var customers = await _context.Customers
                .Where(c => c.CustomerName.Contains(keyword))
                .ToListAsync();

            _logger.LogInformation("Found {Count} customers", customers.Count);

            return customers;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            _logger.LogInformation("Retrieving all customers");

            var customers = await _context.Customers
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Retrieved {Count} customers", customers.Count);

            return customers;
        }

        public async Task UpdateCustomerAsync(Guid id, Customer updatedCustomer)
        {
            _logger.LogInformation("Updating customer. CustomerId: {CustomerId}", id);

            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                _logger.LogWarning("Update failed. Customer not found. CustomerId: {CustomerId}", id);

                throw new NotFoundException("Invalid customer id, Customer not found");
            }

            customer.CustomerName = updatedCustomer.CustomerName;
            customer.CustomerAddress = updatedCustomer.CustomerAddress;
            customer.CustomerPhone = updatedCustomer.CustomerPhone;
            customer.CustomerEmail = updatedCustomer.CustomerEmail;

            await _context.SaveChangesAsync();

            _logger.LogInformation("Customer updated successfully. CustomerId: {CustomerId}", id);
        }
    }
}