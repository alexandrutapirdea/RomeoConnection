namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDeletedToPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserPosts", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserPosts", "IsDeleted");
        }
    }
}
