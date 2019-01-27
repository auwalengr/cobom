namespace cobom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gallary2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.gallary_picture",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        details = c.String(),
                        imgurl = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.gallary_picture");
        }
    }
}
