namespace Property.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonalDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalDetails",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ContactInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactType = c.Int(nullable: false),
                        Details = c.String(),
                        PersonalDetails_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalDetails", t => t.PersonalDetails_Id)
                .Index(t => t.PersonalDetails_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ContactInformations", new[] { "PersonalDetails_Id" });
            DropIndex("dbo.PersonalDetails", new[] { "Id" });
            DropForeignKey("dbo.ContactInformations", "PersonalDetails_Id", "dbo.PersonalDetails");
            DropForeignKey("dbo.PersonalDetails", "Id", "dbo.UserProfile");
            DropTable("dbo.ContactInformations");
            DropTable("dbo.PersonalDetails");
        }
    }
}
