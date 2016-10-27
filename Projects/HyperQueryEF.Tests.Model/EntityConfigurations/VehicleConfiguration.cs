using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HyperQueryEF.Tests.Model.EntityConfigurations
{
    public class VehicleConfiguration : EntityTypeConfiguration<Vehicle>
    {
        public VehicleConfiguration()
        {
            ToTable("Vehicles");
            Property(vehicle => vehicle.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}