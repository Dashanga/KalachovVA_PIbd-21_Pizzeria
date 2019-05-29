namespace PizzeriaServiceImplementDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MessageInfoes", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.PizzaOrders", "ImplementerId", "dbo.Implementers");
            DropIndex("dbo.MessageInfoes", new[] { "CustomerId" });
            DropIndex("dbo.PizzaOrders", new[] { "ImplementerId" });
            DropColumn("dbo.Customers", "Mail");
            DropColumn("dbo.PizzaOrders", "ImplementerId");
            DropTable("dbo.MessageInfoes");
            DropTable("dbo.Implementers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Implementers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImplementerFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MessageInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageId = c.String(),
                        FromMailAddress = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        DateDelivery = c.DateTime(nullable: false),
                        CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PizzaOrders", "ImplementerId", c => c.Int());
            AddColumn("dbo.Customers", "Mail", c => c.String());
            CreateIndex("dbo.PizzaOrders", "ImplementerId");
            CreateIndex("dbo.MessageInfoes", "CustomerId");
            AddForeignKey("dbo.PizzaOrders", "ImplementerId", "dbo.Implementers", "Id");
            AddForeignKey("dbo.MessageInfoes", "CustomerId", "dbo.Customers", "CustomerId");
        }
    }
}
