namespace MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlbumModelChanges : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Albums", new[] { "Artist_id" });
            CreateIndex("dbo.Albums", "Artist_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Albums", new[] { "Artist_Id" });
            CreateIndex("dbo.Albums", "Artist_id");
        }
    }
}
