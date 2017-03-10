namespace FantasyTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcolumnstoplayertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "Team", c => c.String());
            AddColumn("dbo.Players", "Position", c => c.String());
            AddColumn("dbo.Players", "PointsAvg", c => c.Double(nullable: false));
            AddColumn("dbo.Players", "AssistsAvg", c => c.Double(nullable: false));
            AddColumn("dbo.Players", "BlocksAvg", c => c.Double(nullable: false));
            AddColumn("dbo.Players", "StealsAvg", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "StealsAvg");
            DropColumn("dbo.Players", "BlocksAvg");
            DropColumn("dbo.Players", "AssistsAvg");
            DropColumn("dbo.Players", "PointsAvg");
            DropColumn("dbo.Players", "Position");
            DropColumn("dbo.Players", "Team");
        }
    }
}
