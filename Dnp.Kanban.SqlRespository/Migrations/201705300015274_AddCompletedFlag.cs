namespace Dnp.Kanban.SqlRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompletedFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblTask", "IsCompleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblTask", "IsCompleted");
        }
    }
}
