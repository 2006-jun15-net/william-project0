using System.Xml.Serialization;
using ProjectZero.Library.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;
using ProjectZero.Library.Interfaces;

namespace ProjectZero
{
    // this solution is set up to work with either database-first or code-first workflow.

    // if you want to do code-first with migrations, EF needs to be able to see the connection string somehow.
    // either you have the DbContext.OnConfiguring method, or, you implement an IDesignTimeDbContextFactory.
    // then, the command like "dotnet ef migrations add InitialCreate --startup-project ../RestaurantReviews.ConsoleUI/"
    // will work. (in an ASP.NET app, configuring the context in Startup is a third option.)
    public class Dependencies : IDesignTimeDbContextFactory<ProZeroContext>
    {
        public ProZeroContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProZeroContext>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);

            return new ProZeroContext(optionsBuilder.Options);
        }

        public IProZeroRepo CreateProZero()
        {
            var dbContext = CreateDbContext();
            return new ProZeroRepo(dbContext);
        }

        public XmlSerializer CreateXmlSerializer()
        {
            return new XmlSerializer(typeof(List<Customer>));
        }
    }
}