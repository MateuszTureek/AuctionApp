using AuctionApp.Core.DAL.Data.AuctionContext;
using AuctionApp.Core.DAL.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AuctionApp.Core.DAL.Repository.Implement
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
    {
        protected AuctionDbContext _db;
        protected DbSet<TEntity> _dbSet;

        public GenericRepo(AuctionDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public virtual TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}