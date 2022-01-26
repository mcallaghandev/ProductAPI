namespace ProductAPI.Data
{
    using ProductAPI.Models;

    public interface IProductRepository
    {
        bool SaveChanges();

        IEnumerable<SqlProduct> GetAllProducts();

        SqlProduct GetProduct(int id);

        void CreateProduct(SqlProduct product);

        void UpdateProduct(SqlProduct product);

        void DeleteProduct(SqlProduct product);
    }
}
