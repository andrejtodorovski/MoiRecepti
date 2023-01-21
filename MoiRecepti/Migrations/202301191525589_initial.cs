namespace MoiRecepti.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Ime = c.String(nullable: false),
                    Sostojki = c.String(nullable: false),
                    Alergeni = c.String(nullable: false),
                    Opis = c.String(nullable: false),
                    Vid = c.String(nullable: false),
                    NivoNaTezina = c.String(nullable: false),
                    ZaKolkuLica = c.Int(nullable: false),
                    VremePodgotovka = c.Int(nullable: false),
                    Slika = c.String(nullable: false),
                    UserEmail = c.String(),
                    AverageRating = c.Single(nullable: false),
                    TotalViews = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Reviews",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Rating = c.Int(nullable: false),
                    Comment = c.String(),
                    RecipeID = c.Int(nullable: false),
                    UserEmail = c.String(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Recipes", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.RecipeID);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "RecipeID", "dbo.Recipes");
            DropIndex("dbo.Reviews", new[] { "RecipeID" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Recipes");
        }
    }
}
