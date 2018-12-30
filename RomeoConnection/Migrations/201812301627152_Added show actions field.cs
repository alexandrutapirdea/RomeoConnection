namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedshowactionsfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ShowActions", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ShowActions");
        }
    }
}
