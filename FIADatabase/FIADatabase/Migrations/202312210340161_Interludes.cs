namespace FIADatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Interludes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interludes",
                c => new
                    {
                        interludeId = c.Int(nullable: false, identity: true),
                        orderNumber = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        areaMap = c.Binary(),
                        districtMap = c.Binary(),
                        bureauMap = c.Binary(),
                        localMap = c.Binary(),
                        Briefing = c.String(nullable: false),
                        Video = c.String(),
                        AAR = c.String(),
                    })
                .PrimaryKey(t => t.interludeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Interludes");
        }
    }
}
