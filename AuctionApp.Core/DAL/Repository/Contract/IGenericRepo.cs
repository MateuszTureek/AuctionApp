using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Repository.Contract {
    public interface IGenericRepo<TEntity> where TEntity : class {
        Task Add (TEntity entity);
        void Remove (TEntity entity);
        Task<TEntity> GetById (int id);
        IEnumerable<TEntity> GetAll ();
        IEnumerable<TEntity> Find (Expression<Func<TEntity, bool>> predicate);
    }
}