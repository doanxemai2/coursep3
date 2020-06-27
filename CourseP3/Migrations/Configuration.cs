using System.Collections.Generic;
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
            var students = new List<Student>()
            {
                new Student() { Fullname = "Đào Công Kiên", Address = "Hoàng Mai - Hà Nội", Phone = "0121213211", Email = "daocongkien@gmail.com", SemesterId = 1},
                new Student() { Fullname = "Phạm Thanh Hoa", Address = "Thanh Trì - Hà Nội", Phone = "0125343211", Email = "phamthanhhoa@gmail.com", SemesterId = 1},
                new Student() { Fullname = "Nguyễn Tuấn Anh", Address = "Hà Đông - Hà Nội", Phone = "0391213211", Email = "nguyentuananh@gmail.com", SemesterId = 1},
                new Student() { Fullname = "Nguyễn Văn Đạt", Address = "Cầu Giấy - Hà Nội", Phone = "0197513211", Email = "nguyenvandat@gmail.com", SemesterId = 2},
                new Student() { Fullname = "Trần Ngọc Ánh", Address = "Nam Từ Liêm - Hà Nội", Phone = "0121213323", Email = "tranngocanh@gmail.com", SemesterId = 2},
                new Student() { Fullname = "Nguyễn Vân Anh", Address = "Ba Đình - Hà Nội", Phone = "0121213443", Email = "nguyenvananh@gmail.com", SemesterId = 3},
                new Student() { Fullname = "Hồ Quang Khải", Address = "Hoàng Mai - Hà Nội", Phone = "0121232356", Email = "hoquangkhai@gmail.com", SemesterId = 3},
                new Student() { Fullname = "Lê Xuân Bách", Address = "Cầu Giấy - Hà Nội", Phone = "0121213210", Email = "lexuanbach@gmail.com", SemesterId = 4},
                new Student() { Fullname = "Hoàng Tất Thành", Address = "Cầu Giấy - Hà Nội", Phone = "0121213887", Email = "hoangtatthanh@gmail.com", SemesterId = 4},
                new Student() { Fullname = "Bùi Thanh Phong", Address = "Ba Đình - Hà Nội", Phone = "0121213299", Email = "buithanhphong@gmail.com", SemesterId = 1},
                new Student() { Fullname = "Lê Thành Phát", Address = "Hà Đông - Hà Nội", Phone = "0981213211", Email = "lethanhphat@gmail.com", SemesterId = 2},
            };
            foreach (var student in students)
            {
                if (!context.Users.Any(u => u.UserName == student.Email))
                {
                    var user = new ApplicationUser
                    {
                        UserName = student.Email,
                        Email = student.Email,
                        Address = student.Address,
                        Phone = student.Phone,
                        Fullname = student.Fullname,
                        SemesterId = student.SemesterId
                        
                    };
                    userManager.Create(user, "password");
                    userManager.AddToRole(user.Id, "Student");
                }
            }

            var courses = new List<Course>()
            {
                new Course(){ Name = "Web Design for Everybody: Basics of Web Development & Coding", Price = 500, SemesterId = 1, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d2j5ihb19pt1hq.cloudfront.net/sdp_page/s12n_logos/webdesign.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Learn to Design and Create Websites. Build a responsive and accessible web portfolio using HTML5, CSS3, and JavaScript"},
                new Course(){ Name = "Full-Stack Web Development with React", Price = 700, SemesterId = 1, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/eb/cab7f07dd411e8991ff71ead974a6c/Slide1.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Build Complete Web and Hybrid Mobile Solutions. Master front-end web, hybrid mobile app and server-side development in four comprehensive courses."},
                new Course(){ Name = "HTML, CSS, and Javascript for Web Developers", Price = 800, SemesterId = 1, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/83/e258e0532611e5a5072321239ff4d4/jhep-coursera-course4.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "We will start from the ground up by learning how to implement modern web pages with HTML and CSS"},
                new Course(){ Name = "JavaScript, jQuery, and JSON", Price = 750, SemesterId = 1, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/78/bf51e094c211e78308116c229500da/WA4E_thumbnail_JS_1x1.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "It is assumed that learners have already taken the Building Web Applications and Building Database Applications in PHP courses in this specialization."},
                new Course(){ Name = "Programming Foundations with JavaScript, HTML and CSS", Price = 650, SemesterId = 1, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/1d/9ab6c01a0711e5aafd874ac89d7e65/digital-388075_1280.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Learn foundational programming concepts (e.g., functions, for loops, conditional statements) and how to solve problems like a programmer."},
                new Course(){ Name = "Java Programming and Software Engineering Fundamentals", Price = 900, SemesterId = 1, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d2j5ihb19pt1hq.cloudfront.net/sdp_page/s12n_logos/Duke_JavaProgrammingIntrotoSoftware_CM195522.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Explore a Career as a Software Engineer. Learn the basics of programming and software development"},
                new Course(){ Name = "Interactivity with JavaScript", Price = 850, SemesterId = 1, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/d7/216ee0502611e5ab137970bddb1c09/javascript_thumnail_1x1.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "The class will culminate in a  final project - the creation of an interactive HTML5 form that accepts and verifies input."},
                new Course(){ Name = "Full Stack Web and Multiplatform Mobile App Development", Price = 700, SemesterId = 1, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/a4/d69e204d3a11e7bd76e991b22caa52/HKUST_full-stack-banner.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Build Complete Web and Hybrid Mobile Solutions. Master front-end web, hybrid mobile app and server-side development in five comprehensive courses."},
                new Course(){ Name = "Python 3 Programming", Price = 550, SemesterId = 2, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/be/0ce870e9cb11e8b2d233b4be6a9cf3/pythonfluency_1x1_4.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Become a Fluent Python Programmer. Learn the fundamentals and become an independent programmer."},
                new Course(){ Name = "Google IT Automation with Python", Price = 600, SemesterId = 2, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/10/94e64625eb4b41b05e66ed0e5bab30/Xavier-MI-Thompson-119.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Learn in-demand skills like Python, Git, and IT automation to advance your career."},
                new Course(){ Name = "IBM Data Science", Price = 800, SemesterId = 2, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/ed/4131809fe511e8937a7926bc59e37f/Professional-Certificate---Data-Science---600x600---Blu-Text.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Kickstart your Career in Data Science & ML. Master data science, learn Python & SQL, analyze & visualize data, build machine learning models."},
                new Course(){ Name = "Applied Data Science with Python", Price = 950, SemesterId = 2, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/c8/8d6df01eb311e6b5f5f786b289d8ba/pythondatascience_specialization_final.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Gain new insights into your data . Learn to apply data science methods and techniques, and acquire analysis skills."},
                new Course(){ Name = "Programming for Everybody (Getting Started with Python)", Price = 550, SemesterId = 2, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/08/33f720502a11e59e72391aa537f5c9/pythonlearn_thumbnail_1x1.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "This course aims to teach everyone the basics of programming computers using Python."},
                new Course(){ Name = "Python I: Aprendiendo a programar Python", Price = 700, SemesterId = 2, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/bf/af25202b6411e7973bdddc08fd00dc/curso-python_V4.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "This introduction to Python will kickstart your learning of Python for data science, as well as programming in general."},
                new Course(){ Name = "Python for Data Science and AI", Price = 800, SemesterId = 2, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/79/192c002fe111e88780515c581bd11f/Screen-Shot-2018-03-24-at-4.42.07-PM.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "This course is designed to teach you the foundations in order to write simple programs in Python using the most common structures."},
                new Course(){ Name = "Python Basics", Price = 850, SemesterId = 2, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/77/17ca30e9cf11e8931fddf70eb768e1/pythonfluency_1x1_course_1.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "This course introduces the basics of Python 3, including conditional execution and iteration as control structures, and strings and lists as data structures. "},
                new Course(){ Name = "Open Source Software Development, Linux and Git", Price = 700, SemesterId = 3, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/93/ab9a20c81711e8888807689cc8fd41/Introduction-to-Open-Source-Software-Development_-Git-and-Linux.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Launch Your Android App Development Career. Master the knowledge and skills necessary to develop maintainable mobile computing apps"},
                new Course(){ Name = "Android App Development", Price = 750, SemesterId = 3, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/ca/bd3c40bb0811e5ba54dbc0616c905c/AAD-settings.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Learn How To Develop Open Source Software. Get the skills and knowledge you need to develop open source software using Linux, git, and more!"},
                new Course(){ Name = "Linux for Developers", Price = 850, SemesterId = 3, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/2c/b20780cc8d11e8ac2561fe7b0ecdea/Coursera-Specialization-Course-2-Header.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "How to separate the kernel from the entire operating system, making contributions to the kernel"},
                new Course(){ Name = "Linux Server Management and Security", Price = 800, SemesterId = 3, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/a0/abb270118c11e79b3c974b5149e3f3/3.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Whether you are accessing a bank website, Netflix or your home router, chances are that your computer is interacting with a Linux system"},
                new Course(){ Name = "Data Engineering with Google Cloud", Price = 750, SemesterId = 3, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/81/4f605ccfea4c3cb55626902b243a4a/Option-3_1.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Advance your career in data engineering and recommends training to support your preparation for the industry-recognized Google Cloud Professional Data Engineer certification."},
                new Course(){ Name = "Introduction to Cybersecurity Tools & Cyber Attacks", Price = 500, SemesterId = 3, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/a1/4d3f79658647c595a756fba0e715e8/hacker.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "The completion of this course also makes you eligible to earn the Introduction to Cybersecurity Tools & Cyber Attacks IBM digital badge."},
                new Course(){ Name = "Computer Communications", Price = 900, SemesterId = 3, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/07/1d85e07ec211e78ea8bdfc9d4b2d48/redes-informaticas.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Launch your career in computer network & security. Provide an introduction to fundamental network architecture concepts and network design alternatives"},
                new Course(){ Name = "Introduction to Big Data", Price = 700, SemesterId = 4, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/f0/2514c0659311e894d3e7ac680ef0c6/BD-Especialitzacio.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Mejora tu perfil profesional. BIG DATA: una de las disciplinas con mayor demanda de personal cualificado"},
                new Course(){ Name = "Modern Big Data Analysis with SQL", Price = 750, SemesterId = 4, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/e0/9258906e4b11e88932d773ab868ede/GettyImages-835871924_medium_cdaSpec_square.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Data Engineering on Google Cloud Platform. Launch your career in Data Engineering. Deliver business value with big data and machine learning."},
                new Course(){ Name = "Introduction to Data Science", Price = 800, SemesterId = 4, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/10/050240796d11e88ee4d58f19c7d422/Data-Science-Foundations-Logo-Draft-v3.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Learn Data Analysis for Big Data. Master using SQL for data analysis on distributed big data systems"},
                new Course(){ Name = "Big Data Essentials: HDFS, MapReduce and Spark RDD", Price = 850, SemesterId = 4, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/9c/890410a14511e792ff9736c18c3b68/Yandex-466_2.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Launch your career in Data Science. Data Science skills to prepare for a career or further advanced learning in Data Science."},
                new Course(){ Name = "Excel to MySQL: Analytic Techniques for Business", Price = 800, SemesterId = 4, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d2j5ihb19pt1hq.cloudfront.net/sdp_page/s12n_logos/Duke_ExceltoMySQLGetty529354813.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Learn some basic technologies of the modern Big Data landscape, namely: HDFS, MapReduce and Spark"},
                new Course(){ Name = "What is Data Science?", Price = 900, SemesterId = 4, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/16/d602b00a6c11e88d594f951694ab88/Data-Science-Orientation.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Turn Data Into Value. Drive business process change by identifying & analyzing key metrics in 4 industry-relevant courses."},
                new Course(){ Name = "Functional Programming in Scala", Price = 950, SemesterId = 4, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/ca/8934e0188711e69d2049c17d0d6907/twenty20_54db5e50-8425-4ffd-a4fd-8ba5b4813b9a.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Processing large graphs with Spark GraphFrames, Debugging, profiling and optimizing Spark application performance."},
            };
            foreach (var course in courses)
            {
                context.Courses.Add(course);
                context.SaveChanges();
            }
        }
    }
}
