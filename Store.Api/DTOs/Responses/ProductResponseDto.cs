namespace Store.Api.DTOs.Responses
{
    public class ProductResponseDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string CategoryName { get; set; }
    }
}