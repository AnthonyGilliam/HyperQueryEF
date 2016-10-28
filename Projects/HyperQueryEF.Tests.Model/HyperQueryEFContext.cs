using System.Data.Entity;

namespace HyperQueryEF.Tests.Model
{
    public class HyperQueryEFContext : DbContext
    {
        public HyperQueryEFContext() : base("HyperQueryEF.Tests")
        {
        }

        public void Initialize()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<HyperQueryEFContext>());
            //Force database to initialize (Create/Migrate tables).
            Database.Initialize(true);
        }

        public virtual DbSet<Dealership> Dealerships { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Motorcycle> Motorcycles { get; set; }
        public virtual DbSet<SalesPerson> SalesPeople { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(this.GetType().Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}