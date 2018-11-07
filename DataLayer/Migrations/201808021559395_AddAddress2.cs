namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddress2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "PostInfo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addresses", "PostInfo");
        }
    }
}
