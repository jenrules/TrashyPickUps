namespace Trash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentControllerAndView : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Payment = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentModels", "CustomerID", "dbo.Customers");
            DropIndex("dbo.PaymentModels", new[] { "CustomerID" });
            DropTable("dbo.PaymentModels");
        }
    }
}
