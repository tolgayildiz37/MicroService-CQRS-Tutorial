using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Sourcing.Entities;

namespace Tutorial.Sourcing.Data
{
    public class SourcingContextSeed
    {
        public static void SeedData(IMongoCollection<Auction> auctionCollection)
        {
            // .Any ile boolean olarak dönüş yap demek
            bool existProduct = auctionCollection.Find(p => true).Any();

            if (!existProduct)
            {
                auctionCollection.InsertManyAsync(GetConfigureProducts());
            }
        }

        private static IEnumerable<Auction> GetConfigureProducts()
        {
            return new List<Auction>()
            {
                new Auction
                {
                    Name = "Auction 1",
                    Description = "Auction Desc 1",
                    ProductId = "62007d84f721a0ac11cd63ea",
                    CreatedAt = DateTime.Now,
                    StartedAt = DateTime.Now,
                    FinishedAt = DateTime.Now.AddDays(10),
                    Quantity = 1,
                    Status = (int)Status.Active,
                    IncludedSellers= new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com"
                    }

                },
                new Auction
                {
                    Name = "Auction 2",
                    Description = "Auction Desc 2",
                    ProductId = "62007d84f721a0ac11cd63ea",
                    CreatedAt = DateTime.Now,
                    StartedAt = DateTime.Now,
                    FinishedAt = DateTime.Now.AddDays(10),
                    Quantity = 1,
                    Status = (int)Status.Active,
                    IncludedSellers= new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com"
                    }

                },
                new Auction
                {
                    Name = "Auction 3",
                    Description = "Auction Desc 3",
                    ProductId = "62007c30e022708b1e435504",
                    CreatedAt = DateTime.Now,
                    StartedAt = DateTime.Now,
                    FinishedAt = DateTime.Now.AddDays(10),
                    Quantity = 1,
                    Status = (int)Status.Active,
                    IncludedSellers= new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com"
                    }

                }
            };
        }
    }
}
