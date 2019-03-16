namespace PizzeriaServiceImplementDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.PizzaOrders",
                c => new
                    {
                        PizzaOrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        PizzaId = c.Int(nullable: false),
                        PizzaCount = c.Int(nullable: false),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        State = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ImplementationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.PizzaOrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Pizzas", t => t.PizzaId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.PizzaId);
            
            CreateTable(
                "dbo.Pizzas",
                c => new
                    {
                        PizzaId = c.Int(nullable: false, identity: true),
                        PizzaName = c.String(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PizzaId);
            
            CreateTable(
                "dbo.PizzaIngredients",
                c => new
                    {
                        PizzaIngredientId = c.Int(nullable: false, identity: true),
                        PizzaId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                        PizzaIngredientCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PizzaIngredientId)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Pizzas", t => t.PizzaId, cascadeDelete: true)
                .Index(t => t.PizzaId)
                .Index(t => t.IngredientId);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IngredientId);
            
            CreateTable(
                "dbo.StorageIngredients",
                c => new
                    {
                        StorageIngredientId = c.Int(nullable: false, identity: true),
                        StorageId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                        StorageIngredientCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StorageIngredientId)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.StorageId)
                .Index(t => t.IngredientId);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        StorageId = c.Int(nullable: false, identity: true),
                        StorageName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StorageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PizzaOrders", "PizzaId", "dbo.Pizzas");
            DropForeignKey("dbo.PizzaIngredients", "PizzaId", "dbo.Pizzas");
            DropForeignKey("dbo.StorageIngredients", "StorageId", "dbo.Storages");
            DropForeignKey("dbo.StorageIngredients", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.PizzaIngredients", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.PizzaOrders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.StorageIngredients", new[] { "IngredientId" });
            DropIndex("dbo.StorageIngredients", new[] { "StorageId" });
            DropIndex("dbo.PizzaIngredients", new[] { "IngredientId" });
            DropIndex("dbo.PizzaIngredients", new[] { "PizzaId" });
            DropIndex("dbo.PizzaOrders", new[] { "PizzaId" });
            DropIndex("dbo.PizzaOrders", new[] { "CustomerId" });
            DropTable("dbo.Storages");
            DropTable("dbo.StorageIngredients");
            DropTable("dbo.Ingredients");
            DropTable("dbo.PizzaIngredients");
            DropTable("dbo.Pizzas");
            DropTable("dbo.PizzaOrders");
            DropTable("dbo.Customers");
        }
    }
}
