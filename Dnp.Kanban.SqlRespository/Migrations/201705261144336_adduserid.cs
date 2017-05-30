namespace Dnp.Kanban.SqlRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduserid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblProject", "UserID", c => c.String(nullable: false, maxLength: 256));
            AddColumn("dbo.tblTask", "UserID", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblTask", "UserID");
            DropColumn("dbo.tblProject", "UserID");
        }
    }
}
