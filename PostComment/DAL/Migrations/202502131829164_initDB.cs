namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        commentText = c.String(),
                        CommentBy = c.String(maxLength: 128),
                        postID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.postID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CommentBy)
                .Index(t => t.CommentBy)
                .Index(t => t.postID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        PostedBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.PostedBy)
                .Index(t => t.PostedBy);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Uname = c.String(nullable: false, maxLength: 128),
                        password = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Uname);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "CommentBy", "dbo.Users");
            DropForeignKey("dbo.Comments", "postID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "PostedBy", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "PostedBy" });
            DropIndex("dbo.Comments", new[] { "postID" });
            DropIndex("dbo.Comments", new[] { "CommentBy" });
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
