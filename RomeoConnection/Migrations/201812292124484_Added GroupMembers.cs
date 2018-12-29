namespace RomeoConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGroupMembers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupMembers",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        GroupMemberUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GroupId, t.GroupMemberUserId })
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .ForeignKey("dbo.AspNetUsers", t => t.GroupMemberUserId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.GroupMemberUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupMembers", "GroupMemberUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.GroupMembers", "GroupId", "dbo.Groups");
            DropIndex("dbo.GroupMembers", new[] { "GroupMemberUserId" });
            DropIndex("dbo.GroupMembers", new[] { "GroupId" });
            DropTable("dbo.GroupMembers");
        }
    }
}
