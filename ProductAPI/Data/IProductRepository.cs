namespace ProductAPI.Data
{
    using ProductAPI.Models;

    public interface IProductRepository
    {
        bool SaveChanges();

        IEnumerable<Product> GetAllProducts();

        Product GetProduct(int id);

        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);
    }
}
