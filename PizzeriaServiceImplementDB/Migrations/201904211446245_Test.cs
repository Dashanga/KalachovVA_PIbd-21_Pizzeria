namespace PizzeriaServiceImplementDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Implementers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImplementerFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PizzaOrders", "ImplementerId", c => c.Int());
            CreateIndex("dbo.PizzaOrders", "ImplementerId");
            AddForeignKey("dbo.PizzaOrders", "ImplementerId", "dbo.Implementers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PizzaOrders", "ImplementerId", "dbo.Implementers");
            DropIndex("dbo.PizzaOrders", new[] { "ImplementerId" });
            DropColumn("dbo.PizzaOrders", "ImplementerId");
            DropTable("dbo.Implementers");
        }
    }
}
