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
            throw new NotImplementedException();
        }

        public TEntity Get(TKey id)
        {
            throw new NotImplementedException();
        }

        public TEntity GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
