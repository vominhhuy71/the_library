namespace library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Music')");
            Sql("INSERT INTO Genres (Name) VALUES ('Computer')");
            Sql("INSERT INTO Genres (Name) VALUES ('Programming')");
            Sql("INSERT INTO Genres (Name) VALUES ('Science')");
            Sql("INSERT INTO Genres (Name) VALUES ('Math')");
            Sql("INSERT INTO Genres (Name) VALUES ('Comic')");
        }
        
        public override void Down()
        {
        }
    }
}
