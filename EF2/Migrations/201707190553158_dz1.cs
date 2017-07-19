namespace EF2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dz1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T3",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T3", t => t.ParentId)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T3", "ParentId", "dbo.T3");
            DropIndex("dbo.T3", new[] { "ParentId" });
            DropTable("dbo.T3");
        }
    }
}
