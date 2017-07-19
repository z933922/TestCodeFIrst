namespace EF2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zz : DbMigration
    {
        public override void Up()
        {
          
            CreateTable(
                "dbo.T5",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
          
        }
        
        public override void Down()
        {
          
            
         
        }
    }
}
