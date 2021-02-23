using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentApp.Models.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> Entities;

        public Repository(DbContext context)
        {
            Context = context;
            Entities = Context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }
    }
}
