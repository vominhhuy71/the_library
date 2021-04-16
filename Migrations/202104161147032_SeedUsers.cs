namespace library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'405528fc-b0f3-4dc7-840e-77f566eb890f', N'guest@library.com', 0, N'AFGGcp4F0FOls2xK2F1fvTjb6J/gD1n3NeLXaZhQoWW53hWbSc0VUuIUJFSBDoGCog==', N'acc58e8d-4079-4976-a984-eb3e46643335', NULL, 0, 0, NULL, 1, 0, N'guest@library.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9976bf68-53f1-46e7-8d48-8df83423a06a', N'admin@library.com', 0, N'AC8Sa7z4MmGioA+NHNwn5wigljfWntNqrKEoMsvqpZNf4am35D+uRAXs67YTUlfXkQ==', N'7824aecf-d47d-4b0a-aea0-31b5285c9f0e', NULL, 0, 0, NULL, 1, 0, N'admin@library.com')            

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a43c6fbe-d1a1-4df2-b393-e4fc89f5a0fe', N'CanManageBook')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9976bf68-53f1-46e7-8d48-8df83423a06a', N'a43c6fbe-d1a1-4df2-b393-e4fc89f5a0fe')

");
        }
        
        public override void Down()
        {
        }
    }
}
