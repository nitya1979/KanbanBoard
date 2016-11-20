namespace Dnp.Kanban.SqlRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correct_ForeinKey_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblTask", "ProjectStageID", c => c.Int(nullable: false));
            AddColumn("dbo.tblTask", "DueDate", c => c.DateTime());
            DropColumn("dbo.tblTask", "StageID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblTask", "StageID", c => c.Int(nullable: false));
            DropColumn("dbo.tblTask", "DueDate");
            DropColumn("dbo.tblTask", "ProjectStageID");
        }
    }
}
