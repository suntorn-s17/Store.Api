using System.ComponentModel.DataAnnotations;

namespace Store.Api.DTOs.Requests
{
    public class CreateCustomerRequestDto
    {
        [StringLength(100)]
        public string CustomerName { get; set; }

        [StringLength(250)]
        public string CustomerAddress { get; set; }

        [Phone]
        public string CustomerPhone { get; set; }

        [EmailAddress]
        public string CustomerEmail { get; set; }
    }
}