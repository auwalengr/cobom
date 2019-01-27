namespace cobom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class news : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.news",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        body = c.String(),
                        datetime = c.DateTime(nullable: false),
                        imgurl = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.news");
        }
    }
}
