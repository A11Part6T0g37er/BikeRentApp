using BikeRentApp.Models.DAL;
using System;

namespace BikeRentApp.Models
{
   public interface IUnitOfWork : IDisposable
    {
        int Complete();
           IBikeRepository Bikes { get; }
        
    }

}
