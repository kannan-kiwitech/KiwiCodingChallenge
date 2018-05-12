namespace CodingChallenge1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Favourites : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFavourites",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        PropertyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.PropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFavourites", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserFavourites", "PropertyId", "dbo.Properties");
            DropIndex("dbo.UserFavourites", new[] { "PropertyId" });
            DropIndex("dbo.UserFavourites", new[] { "UserId" });
            DropTable("dbo.UserFavourites");
        }
    }
}
