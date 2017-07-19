namespace EF2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dz2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T4",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        T3Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T3", t => t.T3Id, cascadeDelete: true)
                .Index(t => t.T3Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T4", "T3Id", "dbo.T3");
            DropIndex("dbo.T4", new[] { "T3Id" });
            DropTable("dbo.T4");
        }
    }
}
