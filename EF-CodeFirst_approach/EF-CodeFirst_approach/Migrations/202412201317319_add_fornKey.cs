namespace EF_CodeFirst_approach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_fornKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Courses", "DeptId");
            CreateIndex("dbo.Students", "DeptID");
            AddForeignKey("dbo.Courses", "DeptId", "dbo.Departments", "DeptId", cascadeDelete: true);
            AddForeignKey("dbo.Students", "DeptID", "dbo.Departments", "DeptId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "DeptID", "dbo.Departments");
            DropForeignKey("dbo.Courses", "DeptId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DeptID" });
            DropIndex("dbo.Courses", new[] { "DeptId" });
        }
    }
}
