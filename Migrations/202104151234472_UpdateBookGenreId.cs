namespace library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBookGenreId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Books", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Books", name: "IX_Genre_Id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Books", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameColumn(table: "dbo.Books", name: "GenreId", newName: "Genre_Id");
        }
    }
}
