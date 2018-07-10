using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AuctionApp.Core.DAL.Specyfication
{
    public class FilterItemSpecyfication : Specyfication<Item>
    {
        readonly int _catId;
        readonly int _subCatId;
        readonly Status _status;
        Expression<Func<Item, bool>> _expression;

        public FilterItemSpecyfication(Status status, int? categoryId = null, int? subcategoryId = null)
        {
            _status = status;

            if (subcategoryId != null)
            {
                _subCatId = (int)subcategoryId;
                _expression = GetSubcategoryExpression();
            }
            else
            {
                if (categoryId != null)
                {
                    _catId = (int)categoryId;
                    _expression = GetCategoryExpression();
                }
                else
                    _expression = GetOnlyStatusExpression();
            }
        }

        public override Expression<Func<Item, bool>> ToExpression()
        {
            return _expression;
        }

        private Expression<Func<Item, bool>> GetOnlyStatusExpression()
        {
            return (x => x.Status == _status);
        }

        private Expression<Func<Item, bool>> GetCategoryExpression()
        {
            return (x => x.Subcategory.Category.Id == _catId && x.Status == _status);
        }

        private Expression<Func<Item, bool>> GetSubcategoryExpression()
        {
            return (x => x.Subcategory.Id == _subCatId && x.Status == _status);
        }
    }
}