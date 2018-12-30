namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Magic : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "ShowActions");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ShowActions", c => c.Boolean(nullable: false));
        }
    }
}
