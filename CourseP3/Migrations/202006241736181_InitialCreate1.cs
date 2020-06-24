namespace CourseP3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "CategoryCourse_Id1", "dbo.CategoryCourses");
            DropIndex("dbo.Courses", new[] { "CategoryCourse_Id1" });
            DropTable("dbo.CategoryCourses");
            DropTable("dbo.Courses");
            DropTable("dbo.CenterDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CenterDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Hotline = c.Int(nullable: false),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Time = c.DateTime(nullable: false),
                        Description = c.String(),
                        Image = c.String(),
                        Price = c.Int(nullable: false),
                        CategoryCourse_Id = c.String(),
                        Status = c.Int(nullable: false),
                        CategoryCourse_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Courses", "CategoryCourse_Id1");
            AddForeignKey("dbo.Courses", "CategoryCourse_Id1", "dbo.CategoryCourses", "Id");
        }
    }
}
