namespace Dnp.Kanban.SqlRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblTask",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        StageID = c.Int(nullable: false),
                        ShortDescription = c.String(nullable: false, maxLength: 255),
                        LongDescription = c.String(maxLength: 400),
                        Priority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblTask");
        }
    }
}
