namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Statusforcomments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostComments", "CommentStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostComments", "CommentStatus");
        }
    }
}
