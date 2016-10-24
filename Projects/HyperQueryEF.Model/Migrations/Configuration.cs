using System.Data.Entity.Migrations;

namespace HyperQueryEF.Model.Migrations
{
    /// <summary>
    /// Sets database initializer configuration to EF Migrations with Automatic Migrations disabled.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<HyperQueryEFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HyperQueryEF.Model.HyperQueryEFContext";
        }

        /// <summary>
        /// Seed entity model data. This method will be called after migrating to the latest version.
        /// </summary>
        /// <param name="context">DbContext for project</param>
        protected override void Seed(HyperQueryEFContext context)
        {
            
        }
    }
}
