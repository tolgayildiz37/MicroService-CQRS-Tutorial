using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using Tutorial.Sourcing.Entities.Interfaces;

namespace Tutorial.Sourcing.Entities
{
    public class Bid : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string AuctionId { get; set; }
        public string ProductId { get; set; }
        public string SellerUserName { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
