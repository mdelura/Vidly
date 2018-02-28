namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Vidly.Models;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'227312f6-d2d1-4c8a-9f22-9c729de07247', N'guest@vidly.com', 0, N'AFEF/sz5AqaXYx/3KyncYZlI1zbqrM1zKqoCy2ljlITpGzs2wL5FQ1xEVWzP4OGz1A==', N'e1129773-a283-411e-9683-62ca20a0234f', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'45a9cd4d-b67b-4157-8d32-69411f0a431c', N'admin@vidly.com', 0, N'AFg7BU7Hs5KGKsNJgp4HTou5dhhB2cv2S10Pz3GbnQkwaksYgG4lc93yRLnyvdqOjw==', N'111f0239-c553-4610-b920-b2698bd8d571', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'11c1e921-7a07-4877-aa26-09c616a9bd8e', N'" + RoleName.CanManageMovies + @"')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'45a9cd4d-b67b-4157-8d32-69411f0a431c', N'11c1e921-7a07-4877-aa26-09c616a9bd8e')
");
        }
        
        public override void Down()
        {
        }
    }
}
