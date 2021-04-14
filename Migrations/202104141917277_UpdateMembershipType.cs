namespace library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Student' WHERE Id = 1");

            Sql("UPDATE MembershipTypes SET Name = 'Teacher' WHERE Id = 2");

            Sql("UPDATE MembershipTypes SET Name = 'Guest' WHERE Id = 3");

        }
        
        public override void Down()
        {
        }
    }
}
