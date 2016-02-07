namespace Oplog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultPic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "IsDefaultPic", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Files", "IsDefaultPic");
        }
    }
}
