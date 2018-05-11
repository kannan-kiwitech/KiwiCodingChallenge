namespace CodingChallenge1.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Property : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Properties",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Name = c.String(),
                    City = c.String(),
                    State = c.String(),
                    Country = c.String(),
                    ZipCode = c.String(),
                    ImageUrl = c.String(),
                    Latilatitude = c.Double(nullable: false),
                    Longitude = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Properties");
        }
    }
}