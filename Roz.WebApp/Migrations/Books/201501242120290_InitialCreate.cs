using System.Data.Entity.Migrations;

namespace Roz.WebApp.Migrations.Books
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Domain.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        ISBN = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Domain.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        ReviewText = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Domain.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Domain.Reviews", "BookID", "Domain.Books");
            DropIndex("Domain.Reviews", new[] { "BookID" });
            DropTable("Domain.Reviews");
            DropTable("Domain.Books");
        }
    }
}
