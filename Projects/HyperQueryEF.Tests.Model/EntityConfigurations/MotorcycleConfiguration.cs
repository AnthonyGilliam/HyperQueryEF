using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HyperQueryEF.Tests.Model.EntityConfigurations
{
    public class MotorcycleConfiguration : EntityTypeConfiguration<Motorcycle>
    {
        public MotorcycleConfiguration()
        {
            ToTable("Motorcycles");
        }
    }
}