using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace UCM.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CampusManagementContext>
    {
        public CampusManagementContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).ToString() + "\\UCM.Api\\")
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<CampusManagementContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");//@"Server=DESKTOP-99S221B;Database=CampusManagementDb;Trusted_Connection=True;");

            //var connectionString = "Server=den1.mssql8.gear.host; Database=dotnot;User Id=dotnot;Password=Do75j23S!1!v;";
            builder.UseSqlServer(connectionString);
            return new CampusManagementContext(builder.Options);
        }
    }
}
