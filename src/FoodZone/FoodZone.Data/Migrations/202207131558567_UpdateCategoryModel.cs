namespace FoodZone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCategoryModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Foods", new[] { "CategoryId" });
            AlterColumn("dbo.Foods", "CategoryId", c => c.Int());
            CreateIndex("dbo.Foods", "CategoryId");
            AddForeignKey("dbo.Foods", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Foods", new[] { "CategoryId" });
            AlterColumn("dbo.Foods", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Foods", "CategoryId");
            AddForeignKey("dbo.Foods", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
