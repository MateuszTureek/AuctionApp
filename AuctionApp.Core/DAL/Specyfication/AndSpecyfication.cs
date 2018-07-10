using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AuctionApp.Core.DAL.Specyfication
{
    public class AndSpecyfication<TEntity> : Specyfication<TEntity>
    {
        readonly Specyfication<TEntity> _left;
        readonly Specyfication<TEntity> _right;

        public AndSpecyfication(Specyfication<TEntity> left, Specyfication<TEntity> right)
        {
            _left = left;
            _right = right;
        }

        public override Expression<Func<TEntity, bool>> ToExpression()
        {
            Expression<Func<TEntity, bool>> leftExpression = _left.ToExpression();
            Expression<Func<TEntity, bool>> rightExpression = _right.ToExpression();

            BinaryExpression andExpression = Expression.And(leftExpression.Body, rightExpression.Body);

            return Expression.Lambda<Func<TEntity, bool>>(andExpression, leftExpression.Parameters.Single());
        }
    }
}