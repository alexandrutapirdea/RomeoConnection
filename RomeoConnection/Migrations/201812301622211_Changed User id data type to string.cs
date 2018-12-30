namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUseriddatatypetostring : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "DisplayId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DisplayId");
        }
    }
}
