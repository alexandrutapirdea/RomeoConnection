namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedgroupposts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 3000),
                        PostPicture = c.Binary(),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.GroupId);
            
            AddColumn("dbo.PostComments", "GroupPost_Id", c => c.Int());
            CreateIndex("dbo.PostComments", "GroupPost_Id");
            AddForeignKey("dbo.PostComments", "GroupPost_Id", "dbo.GroupPosts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupPosts", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.PostComments", "GroupPost_Id", "dbo.GroupPosts");
            DropForeignKey("dbo.GroupPosts", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.PostComments", new[] { "GroupPost_Id" });
            DropIndex("dbo.GroupPosts", new[] { "GroupId" });
            DropIndex("dbo.GroupPosts", new[] { "ApplicationUserId" });
            DropColumn("dbo.PostComments", "GroupPost_Id");
            DropTable("dbo.GroupPosts");
        }
    }
}
