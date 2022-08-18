namespace FoodZone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserModel1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Token");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Token", c => c.String());
        }
    }
}
