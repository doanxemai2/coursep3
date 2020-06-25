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
                new Course() { Name = "Finance & Quantitative Modeling for Analysts", Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/28/3d88b3745e4072901d6db7fb8d2f9c/financeModeling_specialization_coursera.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Price = 150, Description = "" },
                new Course() { Name = "C++ For C Programmers Part A", Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/51/af81efe486417a81ab080be3ed731a/C-PartA.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Price = 150, Description = "This course is for experienced C programmers who want to program in C++. The examples and exercises require a basic understanding of algorithms and object-oriented software" },
                new Course() { Name = "Introduction to Python", Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/d8/4765b4214046f98133f1c5209d90a3/python2-4785225_1920.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Price = 150, Description = "" }
                //new Course() { Name = "", Image = "?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Price = 150, Description = "" },
                //new Course() { Name = "", Image = "?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Price = 150, Description = "" },
                //new Course() { Name = "", Image = "?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Price = 150, Description = "" },
                //new Course() { Name = "", Image = "?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Price = 150, Description = "" }
            );
            context.FAQs.AddOrUpdate(x => x.Id,
                new FAQ() { Question = "How to join the course?", Answer = "On this the admin should be able to enter or update the procedures for joining the course that the institute offers." },
                new FAQ() { Question = "Why to join the institute?", Answer = "The various benefits that the student can gain by joining the institution is to be provided." },
                new FAQ() { Question = "When will be Entrance Examinations Conducted?", Answer = "Once in 6 months, and one need to check the website for knowing when is the entrance exam entitled, the fees for the entrance exam (admin will decide and displayed on the application form), etc. are to be listed." },
                new FAQ() { Question = "Can I use the Lab facilities after my class hours? Will there be any extra hidden charges?", Answer = "Yes, you can use the lab sessions even after your class hours. There will be no charges during the course days (i.e., during the course period if you want to use the lab sessions after the class hours we do provide the lab session and the labs will be kept opened till 9 PM in the evening. But yes if you want to use the lab session after your course completion, then it will be charged based on the scenario (like 1000$ if opted at the time of registering and 1500$ if opted after the completion of the course." },
                new FAQ() { Question = "How can I apply for the entrance exam?", Answer = "Once the entrance exams are entitled, one need to visit the centre for applying it through paper and fill all the necessary details through online. On the application form one should chose which course he/she wanted to pursue." },
                new FAQ() { Question = "Will there be any fees for the entrance exam?", Answer = "Yes there will be and it will be available on the application form." },
                new FAQ() { Question = " How to make the payment?", Answer = "Payment can be done through draft, or through cheque or through cash. For making the payment through cash, one needs to come to one of the centre of the institute, and make the payment there itself. Once the payment is done (through cash or through DD), the student will be provided with the receipt with a receipt number. This receipt number is to be inputted in the application form. For the payments done through cheque and DD, one need to enter the DD number and the cheque number, bank details, etc. are to be entered on the application form and the cheque is to be pinned to the application form. Only once the payment is received the student’s application will be accepted. Once the application is accepted, the student is mailed with the acknowledgement form along with the details of the examination, subject chosen, date and time of exam, and the roll number." }
            );
        }
    }
}
