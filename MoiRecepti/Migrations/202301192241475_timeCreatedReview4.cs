namespace MoiRecepti.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timeCreatedReview4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Recipes", "CreatedOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
