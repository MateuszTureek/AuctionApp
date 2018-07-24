using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Specyfication.Contract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AuctionApp.Core.DAL.Specyfication
{
    public class OrderInAuctionItemSpecyfication : ISpec<Item, object>
    {
        readonly InAuctionItemsOrderBy _orderBy;
        Expression<Func<Item, object>> _expression;

        public OrderInAuctionItemSpecyfication(InAuctionItemsOrderBy orderBy)
        {
            _orderBy = orderBy;

            switch (_orderBy)
            {
                case InAuctionItemsOrderBy.BuyNowPrice: { _expression = (x => x.ConstPrice); break; }
                case InAuctionItemsOrderBy.Payment: { _expression = (x => x.Payment.Name); break; }
                case InAuctionItemsOrderBy.StartDate: { _expression = (x => x.Payment.Name); break; }
                case InAuctionItemsOrderBy.EndDate: { _expression = (x => x.Payment.Name); break; }
                default: { _expression = (x => x.Name); break; }
            }
        }

        public Expression<Func<Item, object>> ToExpression()
        {
            return _expression;
        }
    }
}
