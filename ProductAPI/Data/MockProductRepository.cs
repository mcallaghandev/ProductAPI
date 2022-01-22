namespace ProductAPI.Data
{
    using ProductAPI.Models;
    using System.Collections.Generic;

    public class MockProductRepository : IProductRepository
    {
        public void CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return new List<Product> {
                new Product { Id = 0, Description = "Pom Pom fluffy thing", PriceExVat = 100, PriceIncVat = 120, CreatedDateTime = DateTime.UtcNow, Title = "Pom Poms" },
                new Product { Id = 0, Description = "card with your name on it", PriceExVat = 100, PriceIncVat = 120, CreatedDateTime = DateTime.UtcNow, Title = "custom card" },
                new Product { Id = 0, Description = "box with custom writing on", PriceExVat = 100, PriceIncVat = 120, CreatedDateTime = DateTime.UtcNow, Title = "Picture box" }
            };
        }

        public Product GetProduct(int id)
        {
            return new Product { Id = 0, Description = "Pom Pom fluffy thing", PriceExVat = 100, PriceIncVat = 120, CreatedDateTime = DateTime.UtcNow, Title = "Pom Poms" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
