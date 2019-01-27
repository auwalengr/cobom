namespace cobom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class news13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.news", "newscategoryid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.news", "newscategoryid");
        }
    }
}
