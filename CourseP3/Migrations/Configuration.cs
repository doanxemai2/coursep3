using CourseP3.Areas.Admin.Models;
using CourseP3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CourseP3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CourseP3.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CourseP3.Models.ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole("Admin");
                roleManager.Create(role);

            }
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole("User");
                roleManager.Create(role);

            }
            if (!context.Users.Any(u => u.UserName == "admin@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com"
                };
                userManager.Create(user, "password");
                userManager.AddToRole(user.Id, "Admin");
            }
            if (!context.Users.Any(u => u.UserName == "user@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "user@gmail.com",
                    Email = "user@gmail.com"
                };
                userManager.Create(user, "password");
                userManager.AddToRole(user.Id, "User");
            }
            context.Courses.AddOrUpdate(x => x.Id,
                new Course() { Name = "Finance & Quantitative Modeling for Analysts", Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/28/3d88b3745e4072901d6db7fb8d2f9c/financeModeling_specialization_coursera.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Price = 150, Description = ""},
                new Course() { Name = "C++ For C Programmers Part A", Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/51/af81efe486417a81ab080be3ed731a/C-PartA.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Price = 150, Description = "This course is for experienced C programmers who want to program in C++. The examples and exercises require a basic understanding of algorithms and object-oriented software" },
                new Course() { Name = "Introduction to Python", Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/d8/4765b4214046f98133f1c5209d90a3/python2-4785225_1920.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Price = 150, Description = "" }
                //new Course() { Name = "", Image = "?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Price = 150, Description = "" },
                //new Course() { Name = "", Image = "?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Price = 150, Description = "" },
                //new Course() { Name = "", Image = "?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Price = 150, Description = "" },
                //new Course() { Name = "", Image = "?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Price = 150, Description = "" }
            );
        }
    }
}
