using BikeRentApp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentApp.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BikeContext _context;

        public UnitOfWork(BikeContext context)
        {
           
                _context = context;
                Bikes = new BikeRepository(_context);
               
            
        }

        public IBikeRepository Bikes { get; private set; }



        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
