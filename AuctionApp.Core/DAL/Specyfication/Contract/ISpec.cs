using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AuctionApp.Core.DAL.Specyfication.Contract {
    public interface ISpec<TEntity, TKey> {
        Expression<Func<TEntity, TKey>> ToExpression ();
    }
}