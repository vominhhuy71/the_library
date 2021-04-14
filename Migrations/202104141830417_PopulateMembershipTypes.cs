namespace library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SignupFee, DurationInMonths) VALUES (1,0,12)");
            Sql("INSERT INTO MembershipTypes (Id, SignupFee, DurationInMonths) VALUES (2,0,12)");
            Sql("INSERT INTO MembershipTypes (Id, SignupFee, DurationInMonths) VALUES (3,30,6)");

        }
        
        public override void Down()
        {
        }
    }
}
