namespace Store.Api.DTOs.Responses
{
    public class OrderResponseDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderDetailResponseDto> OrderDetails { get; set; }
    }

    public class OrderDetailResponseDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}