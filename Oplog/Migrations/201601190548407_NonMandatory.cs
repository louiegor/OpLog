namespace Oplog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NonMandatory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Organizations", "ImageId", "dbo.Files");
            DropForeignKey("dbo.OrganizationTypes", "FileId", "dbo.Files");
            DropIndex("dbo.Organizations", new[] { "ImageId" });
            DropIndex("dbo.OrganizationTypes", new[] { "FileId" });
            AlterColumn("dbo.Organizations", "ImageId", c => c.Int());
            AlterColumn("dbo.OrganizationTypes", "FileId", c => c.Int());
            AddForeignKey("dbo.Organizations", "ImageId", "dbo.Files", "Id");
            AddForeignKey("dbo.OrganizationTypes", "FileId", "dbo.Files", "Id");
            CreateIndex("dbo.Organizations", "ImageId");
            CreateIndex("dbo.OrganizationTypes", "FileId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.OrganizationTypes", new[] { "FileId" });
            DropIndex("dbo.Organizations", new[] { "ImageId" });
            DropForeignKey("dbo.OrganizationTypes", "FileId", "dbo.Files");
            DropForeignKey("dbo.Organizations", "ImageId", "dbo.Files");
            AlterColumn("dbo.OrganizationTypes", "FileId", c => c.Int(nullable: false));
            AlterColumn("dbo.Organizations", "ImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrganizationTypes", "FileId");
            CreateIndex("dbo.Organizations", "ImageId");
            AddForeignKey("dbo.OrganizationTypes", "FileId", "dbo.Files", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Organizations", "ImageId", "dbo.Files", "Id", cascadeDelete: true);
        }
    }
}
