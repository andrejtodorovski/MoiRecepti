﻿namespace MoiRecepti.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timeCreated1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "CreatedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
