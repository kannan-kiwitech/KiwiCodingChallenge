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
                context.Properties.Add(new Models.Property { Name = "Mayur Vihar 2", City = "New Delhi", State = "New Delhi", Country = "India", ZipCode = "110091", Latitude = 28.6170636, Longitude = 77.292498, Bedrooms = 2, Bathrooms = 2, ImageUrl = "//thumbs.trulia-cdn.com/pictures/thumbs_3/zillowstatic/ISm6rbf8trkkb11000000000.jpg", Price = 15000 });
                context.Properties.Add(new Models.Property { Name = "Kiwi Homes", City = "Noida", State = "Uttar Pradesh", Country = "India", ZipCode = "201303", Latitude = 28.5806854, Longitude = 77.3144092, Bedrooms = 2, Bathrooms = 1, ImageUrl = "//thumbs.trulia-cdn.com/pictures/thumbs_3/zillowstatic/ISibwjj02v3q0e0000000000.jpg", Price = 22000 });
                context.Properties.Add(new Models.Property { Name = "Connaught Place X", City = "New Delhi", State = "New Delhi", Country = "India", ZipCode = "110001", Latitude = 28.6289332, Longitude = 77.2065322, Bedrooms = 1, Bathrooms = 1, ImageUrl = "//thumbs.trulia-cdn.com/pictures/thumbs_3/zillowstatic/ISqpc8z67rjdpx1000000000.jpg", Price = 34000 });
                context.Properties.Add(new Models.Property { Name = "Nehru Hotel", City = "New Delhi", State = "New Delhi", Country = "India", ZipCode = "110019", Latitude = 28.5491653, Longitude = 77.248399, Bedrooms = 3, Bathrooms = 2, ImageUrl = "//thumbs.trulia-cdn.com/pictures/thumbs_3/zillowstatic/IS9dguz7d4iqhg0000000000.jpg", Price = 44000 });
                context.Properties.Add(new Models.Property { Name = "Kerala Home", City = "Thrissur", State = "Kerala", Country = "India", ZipCode = "680712", Latitude = 10.3721721, Longitude = 76.2189334, Bedrooms = 2, Bathrooms = 1, ImageUrl = "//thumbs.trulia-cdn.com/pictures/thumbs_3/zillowstatic/ISushp74q3l86l1000000000.jpg", Price = 10000 });
                context.Properties.Add(new Models.Property { Name = "Dawood Hideout", City = "Mumbai", State = "Maharashtra", Country = "India", ZipCode = "400099", Latitude = 19.0931098, Longitude = 72.8545186, Bedrooms = 3, Bathrooms = 2, ImageUrl = "//thumbs.trulia-cdn.com/pictures/thumbs_3/zillowstatic/ISes6cctrc15cp0000000000.jpg", Price = 11000 });
                context.Properties.Add(new Models.Property { Name = "Colaba Villa", City = "Mumbai", State = "Maharashtra", Country = "India", ZipCode = "400005", Latitude = 18.9095651, Longitude = 72.801681, Bedrooms = 2, Bathrooms = 1, ImageUrl = "//thumbs.trulia-cdn.com/pictures/thumbs_3/zillowstatic/IS2jz6kkamd8zk1000000000.jpg", Price = 34000 });
                context.Properties.Add(new Models.Property { Name = "Borivali Y", City = "Mumbai", State = "Maharashtra", Country = "India", ZipCode = "400092", Latitude = 19.2318116, Longitude = 72.828133, Bedrooms = 1, Bathrooms = 1, ImageUrl = "//thumbs.trulia-cdn.com/pictures/thumbs_3/zillowstatic/IS6214blkok9qb1000000000.jpg", Price = 67000 });
                context.Properties.Add(new Models.Property { Name = "Ramesh Villa", City = "Bangalore", State = "Karnataka", Country = "India", ZipCode = "560037", Latitude = 12.9596071, Longitude = 77.6741397, Bedrooms = 2, Bathrooms = 2, ImageUrl = "//thumbs.trulia-cdn.com/pictures/thumbs_3/zillowstatic/ISinljp8juie6b1000000000.jpg", Price = 73000 });
                context.Properties.Add(new Models.Property { Name = "Hotel Bangalore", City = "Bangalore", State = "Karnataka", Country = "India", ZipCode = "560041", Latitude = 13.19864, Longitude = 77.7044041, Bedrooms = 3, Bathrooms = 2, ImageUrl = "//thumbs.trulia-cdn.com/pictures/thumbs_3/zillowstatic/IS62h0vufoavu50000000000.jpg", Price = 24000 });
                context.Properties.Add(new Models.Property { Name = "MG Road Homes", City = "Bangalore", State = "Karnataka", Country = "India", ZipCode = "560021", Latitude = 12.9758326, Longitude = 77.6034531, Bedrooms = 2, Bathrooms = 1, ImageUrl = "//thumbs.trulia-cdn.com/pictures/thumbs_3/zillowstatic/ISqp0zjjv2yjuv1000000000.jpg", Price = 34000 });
            }
        }
    }
}