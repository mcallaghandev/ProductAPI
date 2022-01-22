namespace ProductAPI.Dtos
{
    public class ProductReadDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public string ImageUrl { get; set; }

        public decimal PriceExVat { get; set; }

        public decimal PriceIncVat { get; set; }
    }
}
