namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReplaceUserwithApplicationuserforthemoment : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Groups", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Users", new[] { "Group_Id" });
            AddColumn("dbo.AspNetUsers", "Group_Id", c => c.Int());
            AlterColumn("dbo.Groups", "CreatedBy_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Groups", "CreatedBy_Id");
            CreateIndex("dbo.AspNetUsers", "Group_Id");
            DropColumn("dbo.Users", "Group_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Group_Id", c => c.Int());
            DropIndex("dbo.AspNetUsers", new[] { "Group_Id" });
            DropIndex("dbo.Groups", new[] { "CreatedBy_Id" });
            AlterColumn("dbo.Groups", "CreatedBy_Id", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Group_Id");
            CreateIndex("dbo.Users", "Group_Id");
            CreateIndex("dbo.Groups", "CreatedBy_Id");
        }
    }
}
