using System;
using Tutorial.Orders.Domain.Entities.Base;

namespace Tutorial.Orders.Domain.Entities
{
    public class Order : Entity
    {
        public string AuctionId { get; set; }
        public string SellerUserName { get; set; }
        public string ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
