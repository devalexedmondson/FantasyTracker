namespace FantasyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedteamforfantasyteamnameandplayertableforroster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        PlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "TeamId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "TeamId");
            AddForeignKey("dbo.AspNetUsers", "TeamId", "dbo.Teams", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "PlayerId", "dbo.Players");
            DropIndex("dbo.Teams", new[] { "PlayerId" });
            DropIndex("dbo.AspNetUsers", new[] { "TeamId" });
            DropColumn("dbo.AspNetUsers", "TeamId");
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
        }
    }
}
