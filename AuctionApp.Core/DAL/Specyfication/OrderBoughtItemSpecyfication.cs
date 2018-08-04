using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using AuctionApp.Core.BLL.Enum;
using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Specyfication.Contract;

namespace AuctionApp.Core.DAL.Specyfication {
    public class OrderBoughtItemSpecyfication : ISpec<Item, object> {
        readonly BoughtItemsOrderBy _orderBy;
        Expression<Func<Item, object>> _expression;

        public OrderBoughtItemSpecyfication (BoughtItemsOrderBy orderBy) {
            _orderBy = orderBy;

            switch (_orderBy) {
                case BoughtItemsOrderBy.Payment:
                    { _expression = (x => x.Payment.Name); break; }
                case BoughtItemsOrderBy.BuyNowPrice:
                    { _expression = (x => x.ConstPrice); break; }
                case BoughtItemsOrderBy.EndDate:
                    { _expression = (x => x.AuctionEnd); break; }
                case BoughtItemsOrderBy.StartDate:
                    { _expression = (x => x.AuctionStart); break; }
                default:
                    { _expression = (x => x.Name); break; }
            }
        }

        public Expression<Func<Item, object>> ToExpression () {
            return _expression;
        }
    }
}