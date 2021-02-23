using BikeRentApp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BikeRentApp.Models
{
    internal class BikeRepository : GenericRepository<Bike>, IBikeRepository
    {
       

        public BikeRepository(BikeContext context) : base(context)
        {
           
        }

        public void Add(Bike entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Bike> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bike> Find(Expression<Func<Bike, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Bike Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bike> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bike> GetAllNonRentedBikes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bike> GetAllRentedBikes()
        {
            throw new NotImplementedException();
        }

        public void Remove(Bike entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Bike> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Bike entity)
        {
            throw new NotImplementedException();
        }
    }
}