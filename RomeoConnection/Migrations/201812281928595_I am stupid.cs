namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Iamstupid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groups", "CreadtedById_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Groups", new[] { "CreadtedById_Id" });
            AddColumn("dbo.Groups", "CreadtedById", c => c.String(nullable: false));
            DropColumn("dbo.Groups", "CreadtedById_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "CreadtedById_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Groups", "CreadtedById");
            CreateIndex("dbo.Groups", "CreadtedById_Id");
            AddForeignKey("dbo.Groups", "CreadtedById_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
