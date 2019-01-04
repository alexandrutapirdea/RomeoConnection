namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPostComment2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostComments", "UserPostId", c => c.Int(nullable: false));
            CreateIndex("dbo.PostComments", "UserPostId");
            AddForeignKey("dbo.PostComments", "UserPostId", "dbo.UserPosts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostComments", "UserPostId", "dbo.UserPosts");
            DropIndex("dbo.PostComments", new[] { "UserPostId" });
            DropColumn("dbo.PostComments", "UserPostId");
        }
    }
}
