namespace CourseP3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hello2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Time", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Time", c => c.DateTime(nullable: false));
        }
    }
}
