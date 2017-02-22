namespace Dnp.Kanban.SqlRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Order_in_Stage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblProjectStage", "Order", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblProjectStage", "Order");
        }
    }
}
