namespace Roz.WebApp.Migrations.Books
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConcurrencyHandling : DbMigration
    {
        public override void Up()
        {
            AddColumn("Domain.Books", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("Domain.Reviews", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("Domain.Reviews", "RowVersion");
            DropColumn("Domain.Books", "RowVersion");
        }
    }
}
