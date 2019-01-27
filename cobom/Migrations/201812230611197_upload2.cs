namespace cobom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upload2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.gallary_picture", "imgurl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.gallary_picture", "imgurl", c => c.String(nullable: false));
        }
    }
}
