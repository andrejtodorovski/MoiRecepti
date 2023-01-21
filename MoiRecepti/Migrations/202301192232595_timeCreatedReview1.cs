namespace MoiRecepti.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timeCreatedReview1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "TimeCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Recipes", "TimeCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "TimeCreated");
            DropColumn("dbo.Recipes", "TimeCreated");
        }
    }
}
