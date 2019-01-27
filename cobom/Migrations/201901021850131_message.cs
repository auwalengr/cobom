namespace cobom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class message : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.messagedetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        body = c.String(),
                        title = c.String(),
                        fa = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.messages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.messages");
            DropTable("dbo.messagedetails");
        }
    }
}
