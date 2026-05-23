namespace Store.Api.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderDetail> OrderDetials { get; set; }
    }
}