namespace ProductAPI.Data
{
    using ProductAPI.Models;

    public interface IAsyncProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();

        Task<Product> GetProduct(string id);

        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);
    }
}
