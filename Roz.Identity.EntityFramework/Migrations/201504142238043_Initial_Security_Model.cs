namespace Roz.Identity.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Security_Model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Security.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Security.UserRole",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("Security.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Security.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "Security.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Security.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Security.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Security.UserLogin",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("Security.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Security.UserRole", "UserId", "Security.User");
            DropForeignKey("Security.UserLogin", "User_Id", "Security.User");
            DropForeignKey("Security.UserClaim", "UserId", "Security.User");
            DropForeignKey("Security.UserRole", "RoleId", "Security.Role");
            DropIndex("Security.UserLogin", new[] { "User_Id" });
            DropIndex("Security.UserClaim", new[] { "UserId" });
            DropIndex("Security.UserRole", new[] { "UserId" });
            DropIndex("Security.UserRole", new[] { "RoleId" });
            DropTable("Security.UserLogin");
            DropTable("Security.UserClaim");
            DropTable("Security.User");
            DropTable("Security.UserRole");
            DropTable("Security.Role");
        }
    }
}
