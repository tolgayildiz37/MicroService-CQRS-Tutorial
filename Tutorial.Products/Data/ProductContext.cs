using MongoDB.Driver;
using Tutorial.Products.Data.Interfaces;
using Tutorial.Products.Entities;
using Tutorial.Products.Settings;

namespace Tutorial.Products.Data
{
    //Startup.cs'e inversion of control ile eklendi
    public class ProductContext : IProductContext
    {
        public ProductContext(IProductDatabaseSettings _settings)
        {
            var client = new MongoClient(_settings.ConnectionStrings);
            var database = client.GetDatabase(_settings.DatabaseName);

            Products = database.GetCollection<Product>(_settings.CollectionName);
            ProductContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
