namespace VideoRentalStore.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'458befe6-f259-4749-b197-ea776135266d', N'admin@example.com', 0, N'ALNL28SLw/X9hj9sCmMk0Ay2CgG/sLoY6hAgH5c0ShbLLVxNo4lJfA7lRxQxSfJqrQ==', N'55a85aa2-e109-45a8-a2d4-f926a34fd8bd', NULL, 0, 0, NULL, 1, 0, N'admin@example.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b772ba75-119a-4188-800e-53c333798cb6', N'staf@example.com', 0, N'AB6FdDP9sTZDt3vci8q8pSbJl/Kd1NCvZeCD6/kz1X9UUqv4NA4/LUPbt5PiWwvGvQ==', N'02500e26-5318-46b5-84e1-151838cb051c', NULL, 0, 0, NULL, 1, 0, N'staf@example.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1140a437-4616-410c-b370-6842149f0501', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'458befe6-f259-4749-b197-ea776135266d', N'1140a437-4616-410c-b370-6842149f0501')
                ");
        }

        public override void Down()
        {
        }
    }
}
