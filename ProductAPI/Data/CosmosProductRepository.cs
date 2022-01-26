namespace ProductAPI.Data
{
    using Microsoft.Azure.Cosmos;
    using ProductAPI.Models;
    using System.Collections.Generic;

    public class CosmosProductRepository : IAsyncProductRepository
    {
        private readonly Container _container;
        private const string GetAllProductsQuery = "SELECT * FROM c";

        public CosmosProductRepository(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async void CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            product.Id = Guid.NewGuid().ToString();

            await this._container.CreateItemAsync<Product>(product, new PartitionKey(product.Id));
        }

        public async void DeleteProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            await this._container.DeleteItemAsync<Product>(product.Id, new PartitionKey(product.Id));
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var query = this._container.GetItemQueryIterator<Product>(new QueryDefinition(GetAllProductsQuery));
            var results = new List<Product>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<Product> GetProduct(string id)
        {
            try
            {
                ItemResponse<Product> response = await this._container.ReadItemAsync<Product>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async void UpdateProduct(Product product)
        {
            await this._container.UpsertItemAsync<Product>(product, new PartitionKey(product.Id));
        }
    }
}
