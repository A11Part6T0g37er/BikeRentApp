using BikeRentApp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentApp.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BikeContext _context = new BikeContext();
        private  BikeRepository bikeRepository;

        public BikeRepository Bikes
        {
            get
            {
                if (bikeRepository == null)
                    bikeRepository = new BikeRepository(_context);
                return bikeRepository;
            }
        }
        

        private bool disposed = false;

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
