using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using AuctionApp.Core.DAL.Specyfication.Contract;

namespace AuctionApp.Core.DAL.Specyfication {
    public abstract class Specyfication<TEntity> : ISpec<TEntity, bool> {
        public bool IsSatisfiedBy (TEntity entity) {
            Func<TEntity, bool> predicate = ToExpression ().Compile ();
            return predicate (entity);
        }

        public abstract Expression<Func<TEntity, bool>> ToExpression ();
    }
}