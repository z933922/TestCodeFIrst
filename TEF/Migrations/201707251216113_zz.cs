namespace TEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.M1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10, fixedLength: true),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.M1", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.M2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        M1Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.M1", t => t.M1Id, cascadeDelete: true)
                .Index(t => t.M1Id);
            
            CreateTable(
                "dbo.M3",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.M2", "M1Id", "dbo.M1");
            DropForeignKey("dbo.M1", "ParentId", "dbo.M1");
            DropIndex("dbo.M2", new[] { "M1Id" });
            DropIndex("dbo.M1", new[] { "ParentId" });
            DropTable("dbo.M3");
            DropTable("dbo.M2");
            DropTable("dbo.M1");
        }
    }
}
