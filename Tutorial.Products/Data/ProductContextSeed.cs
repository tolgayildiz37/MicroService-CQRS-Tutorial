using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Tutorial.Products.Entities;

namespace Tutorial.Products.Data
{
    public class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            // .Any ile boolean olarak dönüş yap demek
            bool existProduct = productCollection.Find(p => true).Any();

            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetConfigureProducts());
            }
        }

        private static IEnumerable<Product> GetConfigureProducts()
        {
            return new List<Product>()
            {
                new Product
                {
                    Name = "Apple iPhone 13",
                    Summary = "Apple telefon",
                    Description = "Telefon la işte neyin tanımı bu",
                    ImageFile = "iphone-13.png",
                    Price = 17500.00M,
                    Category = "Akıllı Telefon"
                },
                new Product
                {
                    Name = "Huawei Mate 20 Lite",
                    Summary = "Huawei telefon",
                    Description = "Telefon la işte neyin tanımı bu",
                    ImageFile = "huawei-m20-lite.png",
                    Price = 1500.00M,
                    Category = "Akıllı Telefon"
                },
                new Product
                {
                    Name = "Samsung Galaxy S3",
                    Summary = "Samsung telefon",
                    Description = "Telefon la işte neyin tanımı bu",
                    ImageFile = "samsung-galaxy-s3.png",
                    Price = 500.00M,
                    Category = "Akıllı Telefon"
                },
                new Product
                {
                    Name = "Xiaomi Note 10 Pro",
                    Summary = "Xiaomi telefon",
                    Description = "Telefon la işte neyin tanımı bu",
                    ImageFile = "note-10-pro.png",
                    Price = 3500.00M,
                    Category = "Akıllı Telefon"
                }
            };
        }
    }
}
