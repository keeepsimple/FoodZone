namespace FoodZone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserMenu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserMenus", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.UserMenus", "UserId", "dbo.Users");
            DropIndex("dbo.UserMenus", new[] { "UserId" });
            DropIndex("dbo.UserMenus", new[] { "MenuId" });
            DropTable("dbo.UserMenus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        MenuId = c.Int(nullable: false),
                        Rate = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        InsertedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UserMenus", "MenuId");
            CreateIndex("dbo.UserMenus", "UserId");
            AddForeignKey("dbo.UserMenus", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.UserMenus", "MenuId", "dbo.Menus", "Id", cascadeDelete: true);
        }
    }
}
