namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedforeinkeypropertiestoGroup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groups", "CreatedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Groups", new[] { "CreatedBy_Id" });
            AddColumn("dbo.Groups", "CreadtedById", c => c.String(nullable: false));
            AlterColumn("dbo.Groups", "CreatedBy_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Groups", "CreatedBy_Id");
            AddForeignKey("dbo.Groups", "CreatedBy_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "CreatedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Groups", new[] { "CreatedBy_Id" });
            AlterColumn("dbo.Groups", "CreatedBy_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Groups", "CreadtedById");
            CreateIndex("dbo.Groups", "CreatedBy_Id");
            AddForeignKey("dbo.Groups", "CreatedBy_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
