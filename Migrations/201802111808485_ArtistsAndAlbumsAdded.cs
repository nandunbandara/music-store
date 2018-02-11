namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArtistsAndAlbumsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Released = c.DateTime(nullable: false),
                        genre = c.String(),
                        length = c.String(),
                        recorded = c.Int(nullable: false),
                        Artist_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Artists", t => t.Artist_id)
                .Index(t => t.Artist_id);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "Artist_id", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "Artist_id" });
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
