namespace ServiceEndpoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drinks",
                c => new
                    {
                        DrinkId = c.Int(nullable: false, identity: true),
                        DrinkName = c.String(),
                        Quantity = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DrinkId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Drinks");
        }
    }
}
