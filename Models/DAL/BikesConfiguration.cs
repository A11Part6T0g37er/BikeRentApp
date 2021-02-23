using System.Data.Entity.ModelConfiguration;

namespace BikeRentApp.Models.DAL
{
    internal class BikesConfiguration : EntityTypeConfiguration<Bike>
    {
        public BikesConfiguration()
        {
            Property(c => c.ID)
               .IsRequired();

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

           
            

            
        }
    }
}