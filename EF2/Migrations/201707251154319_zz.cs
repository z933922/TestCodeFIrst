namespace EF2.Migrations
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
            
            AlterColumn("dbo.M3", "Name", c => c.String(maxLength: 10, fixedLength: true));
          
        }
        
        public override void Down()
        {
          
        }
    }
}
