namespace Dnp.Kanban.SqlRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_ProjectStage_rel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblTask", "ProjectStage_ID", c => c.Int());
            CreateIndex("dbo.tblTask", "ProjectStage_ID");
            AddForeignKey("dbo.tblTask", "ProjectStage_ID", "dbo.tblProjectStage", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblTask", "ProjectStage_ID", "dbo.tblProjectStage");
            DropIndex("dbo.tblTask", new[] { "ProjectStage_ID" });
            DropColumn("dbo.tblTask", "ProjectStage_ID");
        }
    }
}
