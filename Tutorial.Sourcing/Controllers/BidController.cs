using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Tutorial.Sourcing.Entities;
using Tutorial.Sourcing.Repositories;
using Tutorial.Sourcing.Repositories.Interfaces;

namespace Tutorial.Sourcing.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidRepository _repo;

        public BidController(IBidRepository bidRepository)
        {
            _repo = bidRepository;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<Bid>> Create([FromBody] Bid bid)
        {
            await _repo.Create(bid);

            return Ok();
        }

        [HttpGet("GetBidByAuctionId")]
        [ProducesResponseType(typeof(IEnumerable<Bid>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Bid>>> GetBidByAuctionId(string id)
        {
            IEnumerable<Bid> bids = await ((BidRepository)_repo).GetBidsByAuctionId(id);

            return Ok(bids);
        }

        [HttpGet("GetWinnerBid")]
        [ProducesResponseType(typeof(Bid), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Bid>> GetWinnerBid(string id)
        {
            return Ok(await ((BidRepository)_repo).GetWinnerBid(id));
        }
    }
}
