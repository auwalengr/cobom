namespace cobom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newscategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.newscategories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        category = c.String(),
                        order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.newscategories");
        }
    }
}
