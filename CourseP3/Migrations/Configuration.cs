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
            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@gmail.com"
                };
                userManager.Create(user, "password");
                userManager.AddToRole(user.Id, "Admin");
            }
            if (!context.Users.Any(u => u.UserName == "user"))
            {
                var user = new ApplicationUser
                {
                    UserName = "user",
                    Email = "user@gmail.com"
                };
                userManager.Create(user, "password");
                userManager.AddToRole(user.Id, "User");
            }
        }
    }
}
