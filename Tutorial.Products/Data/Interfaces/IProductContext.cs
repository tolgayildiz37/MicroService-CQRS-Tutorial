using MongoDB.Driver;
using Tutorial.Products.Entities;

namespace Tutorial.Products.Data.Interfaces
{
    public interface IProductContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
