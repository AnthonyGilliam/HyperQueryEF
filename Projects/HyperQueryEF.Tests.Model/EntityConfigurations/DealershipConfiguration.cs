using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HyperQueryEF.Tests.Model.EntityConfigurations
{
    public class DealershipConfiguration : EntityTypeConfiguration<Dealership>
    {
        public DealershipConfiguration()
        {
            Map(map => map.MapInheritedProperties());
            Property(dealership => dealership.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(dealership => dealership.Vehicles);
            HasMany(dealership => dealership.SalesPeople);
        }
    }
}
