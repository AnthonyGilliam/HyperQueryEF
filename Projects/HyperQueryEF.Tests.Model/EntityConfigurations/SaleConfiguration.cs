using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace HyperQueryEF.Tests.Model.EntityConfigurations
{
    public class SaleConfiguration : EntityTypeConfiguration<Sale>
    {
        public SaleConfiguration()
        {
            Map(map => map.MapInheritedProperties());
            HasRequired(sale => sale.Vehicle);
            HasRequired(sale => sale.Customer);
            HasRequired(sale => sale.SalesPerson);
            Property(sale => sale.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(sale => sale.Date).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute()));
        }
    }
}