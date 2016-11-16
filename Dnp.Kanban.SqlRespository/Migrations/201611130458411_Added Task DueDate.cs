namespace Dnp.Kanban.SqlRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaskDueDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblTask", "DueDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblTask", "DueDate");
        }
    }
}
