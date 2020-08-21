namespace MovieRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Web.Mvc.Ajax;

    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id, Name, DiscountRate, DurationInMonths, SignupFee) VALUES(1, 'Pay As You Go', 10, 2, 200)");
            Sql("INSERT INTO MembershipTypes(Id, Name, DiscountRate, DurationInMonths, SignupFee) VALUES(2, 'Monthly', 20, 4,300)");
            Sql("INSERT INTO MembershipTypes(Id, Name, DiscountRate, DurationInMonths, SignupFee) VALUES(3, 'Quarterly', 30, 6, 400)");
            Sql("INSERT INTO MembershipTypes(Id, Name, DiscountRate, DurationInMonths, SignupFee) VALUES(4, 'Annual', 40, 8, 500)");
        }
        
        public override void Down()
        {
        }
    }
}
