namespace Store.Api.DTOs.Requests
{
    public class UpdateOrderRequestDto
    {
        public Guid CustomerId { get; set; }
        public List<UpdateOrderDetailDto> OrderDetails { get; set; }
    }

    public class UpdateOrderDetailDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}