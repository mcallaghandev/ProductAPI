namespace ProductAPI.Data
{
    using ProductAPI.Models;
    using System.Collections.Generic;

    public class SqlProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public SqlProductRepository(ProductContext context)
        {
            _context = context;
        }

        public void CreateProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _context.Products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _context.Products.Remove(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateProduct(Product product)
        {
            
        }
    }
}
