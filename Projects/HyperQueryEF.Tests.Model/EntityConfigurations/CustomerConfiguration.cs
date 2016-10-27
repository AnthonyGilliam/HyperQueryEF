using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HyperQueryEF.Tests.Model.EntityConfigurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Map(map => map.MapInheritedProperties());
            HasMany(customer => customer.Purchases);
            Property(customer => customer.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}