using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Repository.IRepo
{
    public interface IGenericRepo<TKey, TEntity> where TKey : struct
                                                 where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        TEntity Get(TKey id);
        TEntity GetAll();
    }
}
