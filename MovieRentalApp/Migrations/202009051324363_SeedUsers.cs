namespace MovieRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'10a94ef6-ce26-41f5-9b77-6a5e2b8b8ee9', N'admin@movierentalapp.com', 0, N'APYKs9vhUyNhn90hILaVEfNOUJEE1bK9R6fNOCtkOz0z5LGtMnFE+tXGejokRtZLMw==', N'f66b5049-0f7a-4e40-9afa-1d2d74e6fb7b', NULL, 0, 0, NULL, 1, 0, N'admin@movierentalapp.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd536fff0-5d6c-4c3a-bac4-1bed1250e629', N'guest@movierentalapp.com', 0, N'ADiPq+V+KY9QtOzhEAhaPW/EjmFApNp1HrMehda9cWod1+f8t0I4oDrxrq3pj0b5BQ==', N'19df177f-3dc3-482c-a51c-c75ab393b53a', NULL, 0, 0, NULL, 1, 0, N'guest@movierentalapp.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c9f4f0bd-18af-417e-85f5-a6f2c7a337fb', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'10a94ef6-ce26-41f5-9b77-6a5e2b8b8ee9', N'c9f4f0bd-18af-417e-85f5-a6f2c7a337fb')

");
        }
        
        public override void Down()
        {
        }
    }
}
