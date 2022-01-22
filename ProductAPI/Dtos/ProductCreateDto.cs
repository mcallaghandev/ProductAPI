namespace ProductAPI.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class ProductCreateDto
    {
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public DateTime CreatedDateTime { get; set; }

        [Required]
        public decimal PriceExVat { get; set; }

        [Required]
        public decimal PriceIncVat { get; set; }
    }
}
