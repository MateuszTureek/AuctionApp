using AuctionApp.Repository.IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Repository.Repo
{
    public class GenericRepo<TKey, TEntity> : IGenericRepo<TKey, TEntity> where TKey : struct
                                                                         where TEntity : class
    {
        DbContext _context;

        public GenericRepo(DbContext context)
        {
            _context = context;
        }
        
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public TEntity Get(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking().AsEnumerable();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
