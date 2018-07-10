using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Specyfication.Contract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AuctionApp.Core.DAL.Specyfication
{
    public class OrderItemSpecyfication : ISpec<Item, object>
    {
        readonly SortBy _sortBy;
        Expression<Func<Item, object>> _expression;

        public OrderItemSpecyfication(SortBy sortBy)
        {
            _sortBy = sortBy;

            switch (sortBy)
            {
                case SortBy.EndDateAuction:
                    {
                        _expression = OrderByAuctionEndDateExpression();
                        break;
                    }
                case SortBy.PriceBuyNow:
                    {
                        _expression = OrderByConstPriceExpression();
                        break;
                    }
                default:
                    {
                        _expression = OrderByNameExpression();
                        break;
                    }
            }
        }

        public Expression<Func<Item, object>> ToExpression()
        {
            return _expression;
        }

        private Expression<Func<Item, object>> OrderByNameExpression()
        {
            return (x => x.Name);
        }

        private Expression<Func<Item, object>> OrderByAuctionEndDateExpression()
        {
            return (x => x.Auction.EndDate);
        }

        private Expression<Func<Item, object>> OrderByConstPriceExpression()
        {
            return (x => x.ConstPrice);
        }
    }
}