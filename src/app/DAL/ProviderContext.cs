using Common.Utilites;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL
{
    public class ProviderContext : DbContext
    {
        public ProviderContext()
        {
            Database.SetInitializer<ProviderContext>(null);
            var objectContext = (this as IObjectContextAdapter).ObjectContext;

            LoadAppConfig.LoadConfigurationValues();
            this.Database.Connection.ConnectionString = LoadAppConfig.ConnectionString;
            objectContext.CommandTimeout = LoadAppConfig.CommandTimeout;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
