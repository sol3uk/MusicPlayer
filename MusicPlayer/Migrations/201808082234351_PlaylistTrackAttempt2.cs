namespace MusicPlayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlaylistTrackAttempt2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlaylistTracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaylistId = c.Int(nullable: false),
                        TrackId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlaylistTracks");
        }
    }
}
