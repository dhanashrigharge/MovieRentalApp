namespace MovieRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id,Name) VALUES (1,'Horror')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (2,'Romance')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (3,'Action')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (4,'Comedy')");

        }
        
        public override void Down()
        {
        }
    }
}
