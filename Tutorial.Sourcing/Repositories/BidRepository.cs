using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tutorial.Sourcing.Data.Interfaces;
using Tutorial.Sourcing.Entities;
using Tutorial.Sourcing.Repositories.Interfaces;

namespace Tutorial.Sourcing.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly ISourcingContext _context;

        public BidRepository(ISourcingContext context)
        {
            _context = context;
        }

        public async Task Create(Bid entity)
        {
            await _context.Bids.InsertOneAsync(entity);
        }

        public async Task<bool> Delete(Bid entity)
        {
            var filter = Builders<Bid>.Filter.Eq(m => m.Id, entity.Id);
            DeleteResult result = await _context.Bids.DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<Bid> Get(Expression<Func<Bid, bool>> filter)
        {
            return await _context.Bids.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Bid>> GetAll(Expression<Func<Bid, bool>> filter = null)
        {
            return filter == null ?
                await _context.Bids.Find(m => true).ToListAsync() :
                await _context.Bids.Find(filter).ToListAsync();
        }

        public async Task<bool> Update(Bid entity)
        {
            var result = await _context.Bids.ReplaceOneAsync(filter: g => g.Id == entity.Id, replacement: entity);
            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task<List<Bid>> GetBidsByAuctionId(string auctionId)
        {
            var filter = Builders<Bid>.Filter.Eq(m => m.AuctionId, auctionId);
            List<Bid> bids = await _context.Bids.Find(filter).ToListAsync();

            // firmaların son verdikleri tekfifleri listeler
            bids = bids.OrderByDescending(m => m.CreatedAt)
                       .GroupBy(m => m.SellerUserName)
                       .Select(m => new Bid
                       {
                           Id = m.FirstOrDefault().Id,
                           ProductId = m.FirstOrDefault().ProductId,
                           AuctionId = m.FirstOrDefault().AuctionId,
                           Price = m.FirstOrDefault().Price,
                           SellerUserName = m.FirstOrDefault().SellerUserName,
                           CreatedAt = m.FirstOrDefault().CreatedAt
                       })
                       .ToList();

            return bids;
        }

        public async Task<Bid> GetWinnerBid(string auctionId)
        {
            var bids = await GetBidsByAuctionId(auctionId);

            return bids.OrderByDescending(m => m.Price).FirstOrDefault();
        }
    }
}
