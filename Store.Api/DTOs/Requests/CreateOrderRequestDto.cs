namespace Store.Api.DTOs.Requests
{
    public class CreateOrderRequestDto
    {
        public Guid CustomerId { get; set; }
        public List<CreateOrderDetailDto> OrderDetails { get; set; }
    }

    public class CreateOrderDetailDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}