﻿namespace library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomersBirthday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Birthday");
        }
    }
}
