namespace FantasyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNbateamtabletoIDmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NbaTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NbaTeams");
        }
    }
}
