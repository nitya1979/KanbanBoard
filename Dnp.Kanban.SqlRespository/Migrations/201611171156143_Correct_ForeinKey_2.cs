namespace Dnp.Kanban.SqlRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correct_ForeinKey_2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.tblTask", "ProjectStageID");
            AddForeignKey("dbo.tblTask", "ProjectStageID", "dbo.tblProjectStage", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblTask", "ProjectStageID", "dbo.tblProjectStage");
            DropIndex("dbo.tblTask", new[] { "ProjectStageID" });
        }
    }
}
