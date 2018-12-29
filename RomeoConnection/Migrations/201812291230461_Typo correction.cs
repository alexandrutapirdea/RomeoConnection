namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Typocorrection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groups", "CreatedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Groups", new[] { "CreatedBy_Id" });
            RenameColumn(table: "dbo.Groups", name: "CreatedBy_Id", newName: "CreatedById");
            AlterColumn("dbo.Groups", "CreatedById", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Groups", "CreatedById");
            AddForeignKey("dbo.Groups", "CreatedById", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Groups", "CreadtedById");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "CreadtedById", c => c.String(nullable: false));
            DropForeignKey("dbo.Groups", "CreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.Groups", new[] { "CreatedById" });
            AlterColumn("dbo.Groups", "CreatedById", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Groups", name: "CreatedById", newName: "CreatedBy_Id");
            CreateIndex("dbo.Groups", "CreatedBy_Id");
            AddForeignKey("dbo.Groups", "CreatedBy_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
