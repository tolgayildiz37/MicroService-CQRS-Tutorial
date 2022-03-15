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
    public class AuctionRepository : IAuctionRepository
    {
        private readonly ISourcingContext _context;
        public AuctionRepository(ISourcingContext context)
        {
            _context = context;
        }

        public async Task Create(Auction entity)
        {
            await _context.Auctions.InsertOneAsync(entity);
        }

        public async Task<bool> Delete(Auction entity)
        {
            FilterDefinition<Auction> filter = Builders<Auction>.Filter.Eq(m => m.Id, entity.Id);
            DeleteResult result = await _context.Auctions.DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<Auction> Get(Expression<Func<Auction, bool>> filter)
        {
            return await _context.Auctions.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Auction>> GetAll(Expression<Func<Auction, bool>> filter = null)
        {
            return filter == null ?
                await _context.Auctions.Find(m => true).ToListAsync() :
                await _context.Auctions.Find(filter).ToListAsync();
        }

        public async Task<bool> Update(Auction entity)
        {
            var result = await _context.Auctions.ReplaceOneAsync(filter: g => g.Id == entity.Id, replacement: entity);
            return result.IsAcknowledged && result.MatchedCount > 0;
        }
    }
}
