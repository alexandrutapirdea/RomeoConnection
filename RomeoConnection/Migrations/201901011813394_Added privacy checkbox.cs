namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedprivacycheckbox : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsPrivateProfile", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsPrivateProfile", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "IsPublicProfile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "IsPublicProfile", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "IsPrivateProfile");
            DropColumn("dbo.AspNetUsers", "IsPrivateProfile");
        }
    }
}
