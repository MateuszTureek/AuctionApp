using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctionApp.Core.DAL.Data.AuctionContext.Domain
{
    public class Auction
    {
        #region
        DateTime? _startDate;
        DateTime? _endDate;
        int? _bestBidId;
        #endregion

        public int Id { get; set; }

        public int? BestBidId { get { return _bestBidId; } }

        public DateTime? StartDate
        {
            get { return _startDate; }

            set
            {
                _startDate = value;
                //if (_endDate != null) { if (_startDate < _endDate) _startDate = value; }
                //else _startDate = value;
            }
        }

        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                //if (_startDate != null) { if (_endDate > _startDate) { _endDate = value; } }
                //else _startDate = value;
            }
        }

        public Item Item { get; set; }
        public ICollection<Bid> Bids { get; set; }
        #region
        public void AddBid(Bid bid)
        {
            if (Bids == null) throw new NullReferenceException();
            Bids.Add(bid);
        }

        public void SetBestBidId()
        {
            if (Bids != null)
            {
                decimal maxBidAmount = Bids.Max(f => f.BidAmount);
                _bestBidId = Bids.OrderByDescending(o => o.DatePlaced).First(f => f.BidAmount == maxBidAmount).Id;
            }
        }
        #endregion
    }
}
