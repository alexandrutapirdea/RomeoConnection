namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "CreadtedById_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Groups", "CreadtedById_Id");
            AddForeignKey("dbo.Groups", "CreadtedById_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Groups", "CreadtedById");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "CreadtedById", c => c.String(nullable: false));
            DropForeignKey("dbo.Groups", "CreadtedById_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Groups", new[] { "CreadtedById_Id" });
            DropColumn("dbo.Groups", "CreadtedById_Id");
        }
    }
}
