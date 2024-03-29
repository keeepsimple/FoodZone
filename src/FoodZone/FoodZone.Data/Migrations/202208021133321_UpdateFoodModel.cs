﻿namespace FoodZone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFoodModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Foods", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "Image", c => c.String(nullable: false));
        }
    }
}
