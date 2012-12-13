namespace Property.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPortfolio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Owner_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.Owner_UserId, cascadeDelete: true)
                .Index(t => t.Owner_UserId);
            
            CreateTable(
                "dbo.PropertyDescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address_Unit = c.String(),
                        Address_BuildingNumber = c.String(),
                        Address_BuildingName = c.String(),
                        Address_Street = c.String(),
                        Address_Locality = c.String(),
                        Address_Region = c.String(),
                        Address_PostCode = c.String(),
                        Address_Country = c.String(),
                        Portfolio_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Portfolios", t => t.Portfolio_Id)
                .Index(t => t.Portfolio_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.PropertyDescriptions", new[] { "Portfolio_Id" });
            DropIndex("dbo.Portfolios", new[] { "Owner_UserId" });
            DropForeignKey("dbo.PropertyDescriptions", "Portfolio_Id", "dbo.Portfolios");
            DropForeignKey("dbo.Portfolios", "Owner_UserId", "dbo.UserProfile");
            DropTable("dbo.PropertyDescriptions");
            DropTable("dbo.Portfolios");
        }
    }
}
