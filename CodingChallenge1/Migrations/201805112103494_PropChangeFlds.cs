namespace CodingChallenge1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropChangeFlds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "Latitude", c => c.Double(nullable: false));
            DropColumn("dbo.Properties", "Latilatitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Properties", "Latilatitude", c => c.Double(nullable: false));
            DropColumn("dbo.Properties", "Latitude");
        }
    }
}
