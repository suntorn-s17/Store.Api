using System.ComponentModel.DataAnnotations;

namespace Store.Api.DTOs.Requests
{
    public class UpdateProductRequestDto
    {
        [StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(250)]
        public string ProductDescription { get; set; }

        [Range(1, double.MaxValue)]
        public decimal ProductPrice { get; set; }

        public Guid CategoryId { get; set; }
    }
}