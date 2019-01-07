namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNrUsersCollumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "NrUsers", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Groups", "NrUsers");
        }
    }
}
