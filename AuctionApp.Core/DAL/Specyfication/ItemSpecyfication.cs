using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using AuctionApp.Core.DAL.Specyfication.Contract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AuctionApp.Core.DAL.Specyfication
{
    public class ItemSpecyfication : ISpec<Item, bool>
    {
        readonly Status _status;
        readonly string _userId;
        readonly string _phrase;
        Expression<Func<Item, bool>> _expression;

        public ItemSpecyfication(Status status, string userId, string phrase)
        {
            if (string.IsNullOrEmpty(phrase)) _phrase = "";
            else _phrase = phrase;

            _status = status;
            _userId = userId;

            switch (status)
            {
                case Status.InAuction:
                    {
                        _expression = GetExpressionForInAuctionItem();
                        break;
                    }
                case Status.Bought:
                    {
                        _expression = GetExpressionForBoughttem();
                        break;
                    }
                default:
                    {
                        _expression = GetExpressionForWaitingItem();
                        break;
                    }
            }
        }

        public Expression<Func<Item, bool>> ToExpression()
        {
            return _expression;
        }

        Expression<Func<Item, bool>> GetExpression(Status status)
        {
            return w => w.UserId == _userId && w.Status == status && w.Name.Contains(_phrase);
        }

        Expression<Func<Item, bool>> GetExpressionForWaitingItem()
        {
            return GetExpression(Status.Waiting);
        }

        Expression<Func<Item, bool>> GetExpressionForInAuctionItem()
        {
            return GetExpression(Status.InAuction);
        }

        Expression<Func<Item, bool>> GetExpressionForBoughttem()
        {
            return GetExpression(Status.Bought);
        }
    }
}