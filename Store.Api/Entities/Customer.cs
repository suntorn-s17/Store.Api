namespace Store.Api.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}