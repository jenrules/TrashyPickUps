namespace Trash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class collectorDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Collectors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Route = c.String(),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Collectors", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Collectors", new[] { "CustomerID" });
            DropTable("dbo.Collectors");
        }
    }
}
