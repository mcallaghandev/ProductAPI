namespace ProductAPI.Data
{
    using ProductAPI.Models;
    using System.Collections.Generic;

    public class MockProductRepository : IProductRepository
    {
        public void CreateProduct(SqlProduct product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(SqlProduct product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SqlProduct> GetAllProducts()
        {
            return new List<SqlProduct> {
                new SqlProduct { Id = 0, Description = "Pom Pom fluffy thing", PriceExVat = 100, PriceIncVat = 120, CreatedDateTime = DateTime.UtcNow, Title = "Pom Poms" },
                new SqlProduct { Id = 1, Description = "card with your name on it", PriceExVat = 100, PriceIncVat = 120, CreatedDateTime = DateTime.UtcNow, Title = "custom card" },
                new SqlProduct { Id = 2, Description = "box with custom writing on", PriceExVat = 100, PriceIncVat = 120, CreatedDateTime = DateTime.UtcNow, Title = "Picture box" }
            };
        }

        public SqlProduct GetProduct(int id)
        {
            return new SqlProduct { Id = 0, Description = "Pom Pom fluffy thing", PriceExVat = 100, PriceIncVat = 120, CreatedDateTime = DateTime.UtcNow, Title = "Pom Poms" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(SqlProduct product)
        {
            throw new NotImplementedException();
        }
    }
}
