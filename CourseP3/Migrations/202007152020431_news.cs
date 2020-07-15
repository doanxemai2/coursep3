namespace CourseP3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class news : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Semesters", "Name", c => c.String());
            AlterColumn("dbo.Semesters", "Time", c => c.String());
            AlterColumn("dbo.FAQs", "Answer", c => c.String());
            AlterColumn("dbo.News", "Title", c => c.String());
            AlterColumn("dbo.News", "Thumbnail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "Thumbnail", c => c.String(nullable: false));
            AlterColumn("dbo.News", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.FAQs", "Answer", c => c.String(nullable: false));
            AlterColumn("dbo.Semesters", "Time", c => c.String(nullable: false));
            AlterColumn("dbo.Semesters", "Name", c => c.String(nullable: false));
        }
    }
}
