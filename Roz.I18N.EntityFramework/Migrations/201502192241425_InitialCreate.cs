namespace Roz.I18N.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "I18N.Resource",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Key = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "I18N.ResourceValue",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CultureName = c.String(),
                        Value = c.String(),
                        Resource_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("I18N.Resource", t => t.Resource_Id)
                .Index(t => t.Resource_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("I18N.ResourceValue", "Resource_Id", "I18N.Resource");
            DropIndex("I18N.ResourceValue", new[] { "Resource_Id" });
            DropTable("I18N.ResourceValue");
            DropTable("I18N.Resource");
        }
    }
}
