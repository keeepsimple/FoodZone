﻿namespace FoodZone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMenuAndReservationDetailModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ReservationDetails", "MenuPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ReservationDetails", "FoodPrice", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.ReservationDetails", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReservationDetails", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ReservationDetails", "FoodPrice");
            DropColumn("dbo.ReservationDetails", "MenuPrice");
            DropColumn("dbo.Menus", "Price");
        }
    }
}
