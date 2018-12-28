namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsforUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "firstName", c => c.String(nullable: false, maxLength: 254));
            AlterColumn("dbo.Users", "lastName", c => c.String(nullable: false, maxLength: 254));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "lastName", c => c.String());
            AlterColumn("dbo.Users", "firstName", c => c.String());
        }
    }
}
