namespace ProductAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SqlProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedDateTime { get; set; }


        public DateTime? ModifiedDateTime { get; set; }


        public string ImageUrl { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PriceExVat { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PriceIncVat { get; set; }
    }
}
