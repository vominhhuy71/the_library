namespace library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdCard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IdCard", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IdCard");
        }
    }
}
