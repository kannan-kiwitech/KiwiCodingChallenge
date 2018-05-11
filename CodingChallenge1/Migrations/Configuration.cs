namespace CodingChallenge1.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodingChallenge1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CodingChallenge1.Models.ApplicationDbContext";
        }

        protected override void Seed(CodingChallenge1.Models.ApplicationDbContext context)
        {

            if (!context.Properties.Any())
            {
                context.Properties.Add(new Models.Property { Name = "Property 1", City = "New Delhi", State = "New Delhi", Country = "India", ZipCode = "110091", Latilatitude = 28.6139, Longitude = 77.2090 });
                context.Properties.Add(new Models.Property { Name = "Property 2", City = "Banglore", State = "Karnataka", Country = "India", ZipCode = "571119", Latilatitude = 15.3173, Longitude = 75.7139 });
                context.Properties.Add(new Models.Property { Name = "Property 3", City = "Mumbai", State = "Maharashtra", Country = "India", ZipCode = "400090", Latilatitude = 19.0760, Longitude = 72.8777 });
            }
        }
    }
}