namespace Dnp.Kanban.SqlRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblProject",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Description = c.String(nullable: false, maxLength: 400),
                        StartDate = c.DateTime(nullable: false),
                        EstimatedDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tblProjectStage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(nullable: false),
                        StageName = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblProject", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblProjectStage", "ProjectID", "dbo.tblProject");
            DropIndex("dbo.tblProjectStage", new[] { "ProjectID" });
            DropTable("dbo.tblProjectStage");
            DropTable("dbo.tblProject");
        }
    }
}
