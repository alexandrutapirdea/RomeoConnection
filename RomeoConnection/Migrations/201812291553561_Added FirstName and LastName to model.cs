namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFirstNameandLastNametomodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 254));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 254));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
