namespace Dnp.Kanban.SqlRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Est_date : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblProject", "EstimatedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblProject", "EstimatedDate", c => c.DateTime(nullable: false));
        }
    }
}
