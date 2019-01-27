namespace cobom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class news11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.newsComments", "newsid", "dbo.news");
            DropIndex("dbo.newsComments", new[] { "newsid" });
            DropColumn("dbo.news", "newscatid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.news", "newscatid", c => c.Int(nullable: false));
            CreateIndex("dbo.newsComments", "newsid");
            AddForeignKey("dbo.newsComments", "newsid", "dbo.news", "id", cascadeDelete: true);
        }
    }
}
