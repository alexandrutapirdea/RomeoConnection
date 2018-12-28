namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGroupListtoDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 254),
                        Description = c.String(nullable: false, maxLength: 3000),
                        NumberOfUsers = c.Int(nullable: false),
                        CreatedBy_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id, cascadeDelete: true)
                .Index(t => t.CreatedBy_Id);
            
            AddColumn("dbo.Users", "Group_Id", c => c.Int());
            CreateIndex("dbo.Users", "Group_Id");
            AddForeignKey("dbo.Users", "Group_Id", "dbo.Groups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.Groups", "CreatedBy_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Group_Id" });
            DropIndex("dbo.Groups", new[] { "CreatedBy_Id" });
            DropColumn("dbo.Users", "Group_Id");
            DropTable("dbo.Groups");
        }
    }
}
