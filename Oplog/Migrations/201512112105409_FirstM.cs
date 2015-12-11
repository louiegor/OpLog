namespace Oplog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Stat = c.Int(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: false)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                        IsDefault = c.Boolean(nullable: false),
                        CharacterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId, cascadeDelete: false)
                .Index(t => t.CharacterId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        OrgTypeId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrganizationTypes", t => t.OrgTypeId, cascadeDelete: false)
                .ForeignKey("dbo.Files", t => t.ImageId, cascadeDelete: true)
                .Index(t => t.OrgTypeId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.OrganizationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Files", t => t.FileId, cascadeDelete: false)
                .Index(t => t.FileId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.OrganizationTypes", new[] { "FileId" });
            DropIndex("dbo.Organizations", new[] { "ImageId" });
            DropIndex("dbo.Organizations", new[] { "OrgTypeId" });
            DropIndex("dbo.Files", new[] { "CharacterId" });
            DropIndex("dbo.Characters", new[] { "OrganizationId" });
            DropForeignKey("dbo.OrganizationTypes", "FileId", "dbo.Files");
            DropForeignKey("dbo.Organizations", "ImageId", "dbo.Files");
            DropForeignKey("dbo.Organizations", "OrgTypeId", "dbo.OrganizationTypes");
            DropForeignKey("dbo.Files", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.Characters", "OrganizationId", "dbo.Organizations");
            DropTable("dbo.OrganizationTypes");
            DropTable("dbo.Organizations");
            DropTable("dbo.Files");
            DropTable("dbo.Characters");
        }
    }
}
