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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(this.GetType().Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}