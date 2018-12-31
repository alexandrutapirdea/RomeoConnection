namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfilePicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ProfilePicture", c => c.Binary());
            AddColumn("dbo.Users", "ImagePath", c => c.String());
            AddColumn("dbo.Users", "ProfilePicture", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ProfilePicture");
            DropColumn("dbo.Users", "ImagePath");
            DropColumn("dbo.AspNetUsers", "ProfilePicture");
        }
    }
}
