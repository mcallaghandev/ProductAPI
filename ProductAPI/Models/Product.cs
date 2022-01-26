namespace ProductAPI.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    public class Product
    {
        [Key]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [Required]
        [MaxLength (500)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [Required]
        [JsonPropertyName ("createddatetime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonPropertyName ("modifieddatetime")]
        public DateTime? ModifiedDateTime { get; set; }

        [JsonPropertyName ("imageurls")]
        public IEnumerable<string> ImageUrls { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [JsonPropertyName ("priceexvat")]
        public decimal PriceExVat { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [JsonPropertyName ("priceincvat")]
        public decimal PriceIncVat { get; set; }
    }
}
