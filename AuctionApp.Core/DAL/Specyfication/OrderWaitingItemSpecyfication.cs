using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Specyfication.Contract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AuctionApp.Core.DAL.Specyfication
{
    public class OrderWaitingItemSpecyfication : ISpec<Item, object>
    {
        readonly WaitingItemsOrderBy _orderBy;
        Expression<Func<Item, object>> _expression;

        public OrderWaitingItemSpecyfication(WaitingItemsOrderBy orderBy)
        {
            _orderBy = orderBy;

            switch (_orderBy)
            {
                case WaitingItemsOrderBy.BuyNowPrice: { _expression = (x => x.ConstPrice); break; }
                case WaitingItemsOrderBy.Payment: { _expression = (x => x.Payment.Name); break; }
                default: { _expression = (x => x.Name); break; }
            }
        }

        public Expression<Func<Item, object>> ToExpression()
        {
            return _expression;
        }

        public Expression<Func<Item, object>> OrderByPaymentExpression()
        {
            return (x => x.Payment);
        }

        public Expression<Func<Item,object>> OrderByBuyNowPriceExpression()
        {
            return (x => x.ConstPrice);
        }

        public Expression<Func<Item, object>> OrderByNameExpression()
        {
            return (x => x.Name);
        }
    }
}
