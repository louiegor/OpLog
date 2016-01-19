namespace Oplog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "LevelUpCharacterId", c => c.Int());
            AddForeignKey("dbo.Characters", "LevelUpCharacterId", "dbo.Characters", "Id");
            CreateIndex("dbo.Characters", "LevelUpCharacterId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Characters", new[] { "LevelUpCharacterId" });
            DropForeignKey("dbo.Characters", "LevelUpCharacterId", "dbo.Characters");
            DropColumn("dbo.Characters", "LevelUpCharacterId");
        }
    }
}
