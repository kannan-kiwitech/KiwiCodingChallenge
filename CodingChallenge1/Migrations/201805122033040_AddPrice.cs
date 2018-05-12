namespace CodingChallenge1.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "Price", c => c.Double(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Properties", "Price");
        }
    }
}