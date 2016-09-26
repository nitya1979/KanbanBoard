namespace Dnp.Kanban.SqlRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Priority : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblPriority",
                c => new
                    {
                        PriorityID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.PriorityID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblPriority");
        }
    }
}
