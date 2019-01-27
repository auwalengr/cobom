namespace cobom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class archiement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.archievements",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type = c.String(),
                        details = c.String(),
                        location = c.String(),
                        imgurl = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.archievements");
        }
    }
}
