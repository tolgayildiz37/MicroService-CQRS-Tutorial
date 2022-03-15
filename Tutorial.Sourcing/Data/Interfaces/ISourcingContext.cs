using MongoDB.Driver;
using Tutorial.Sourcing.Entities;

namespace Tutorial.Sourcing.Data.Interfaces
{
    public interface ISourcingContext
    {
        IMongoCollection<Auction> Auctions { get; }
        IMongoCollection<Bid> Bids { get; }
    }
}
