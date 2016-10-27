using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HyperQueryEF.Tests.Model.EntityConfigurations
{
    public class SalesPersonConfiguration : EntityTypeConfiguration<SalesPerson>
    {
        public SalesPersonConfiguration()
        {
            Map(map => map.MapInheritedProperties());
            HasMany(salesPerson => salesPerson.Sales);
            Property(salesPerson => salesPerson.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}