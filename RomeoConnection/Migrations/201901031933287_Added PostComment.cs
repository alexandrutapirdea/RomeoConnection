namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPostComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentText = c.String(nullable: false, maxLength: 3000),
                        CommentById = c.String(nullable: false, maxLength: 128),
                        UserPost_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CommentById, cascadeDelete: true)
                .ForeignKey("dbo.UserPosts", t => t.UserPost_Id)
                .Index(t => t.CommentById)
                .Index(t => t.UserPost_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostComments", "UserPost_Id", "dbo.UserPosts");
            DropForeignKey("dbo.PostComments", "CommentById", "dbo.AspNetUsers");
            DropIndex("dbo.PostComments", new[] { "UserPost_Id" });
            DropIndex("dbo.PostComments", new[] { "CommentById" });
            DropTable("dbo.PostComments");
        }
    }
}
