namespace RomeoConnection.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateUsersTable : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Users (firstName, LastName, age, isPublicProfile) values ('John', 'Giumanca',29,'true')");
            Sql("insert into Users (firstName, LastName, age, isPublicProfile) values ('Tap', 'The beast',69,'true')");
            Sql("insert into Users (firstName, LastName, age, isPublicProfile) values ('Alex', 'cat lover',21,'false')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Users where Id in (1,2,3)");
        }
    }
}
