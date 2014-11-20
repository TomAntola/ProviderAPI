using DAL.Utilites;
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
            this.Database.Connection.ConnectionString = LoadAppConfig.ConnectionString;
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = LoadAppConfig.CommandTimeout;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
