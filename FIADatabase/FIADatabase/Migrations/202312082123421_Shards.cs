namespace FIADatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shards : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shards",
                c => new
                    {
                        shardId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.shardId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shards");
        }
    }
}
