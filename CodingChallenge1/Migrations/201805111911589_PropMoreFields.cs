namespace CodingChallenge1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropMoreFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "Address", c => c.String());
            AddColumn("dbo.Properties", "Bedrooms", c => c.Int(nullable: false));
            AddColumn("dbo.Properties", "Bathrooms", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Properties", "Bathrooms");
            DropColumn("dbo.Properties", "Bedrooms");
            DropColumn("dbo.Properties", "Address");
        }
    }
}
