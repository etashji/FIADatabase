namespace FIADatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActI : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActIs",
                c => new
                    {
                        ActIId = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.ActIId);

            
        }
        
        public override void Down()
        {
            DropTable("dbo.ActIs");
        }
    }
}
