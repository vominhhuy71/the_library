namespace library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookNumberAvailable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "NumberAvailable", c => c.Int(nullable: false));
            Sql("UPDATE Books SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "NumberAvailable");
        }
    }
}
