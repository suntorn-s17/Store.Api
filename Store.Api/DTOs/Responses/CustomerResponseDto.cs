namespace Store.Api.DTOs.Responses
{
    public class CustomerResponseDto
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
    }
}