namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedpropertiestoApplicationUserforRegisterPage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Location", c => c.String(maxLength: 254));
            AddColumn("dbo.AspNetUsers", "BirthDay", c => c.String());
            AddColumn("dbo.AspNetUsers", "JobTitle", c => c.String(maxLength: 254));
            AddColumn("dbo.AspNetUsers", "Description", c => c.String(maxLength: 254));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Description");
            DropColumn("dbo.AspNetUsers", "JobTitle");
            DropColumn("dbo.AspNetUsers", "BirthDay");
            DropColumn("dbo.AspNetUsers", "Location");
        }
    }
}
