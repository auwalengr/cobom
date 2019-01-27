namespace cobom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class member2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.members",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Surname = c.String(nullable: false),
                        otherName = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        State = c.String(nullable: false),
                        lga = c.String(nullable: false),
                        phone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.members");
        }
    }
}
