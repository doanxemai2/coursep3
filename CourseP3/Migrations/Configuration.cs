using CourseP3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace CourseP3.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CourseP3.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CourseP3.Models.ApplicationDbContext";
        }

        protected override void Seed(CourseP3.Models.ApplicationDbContext context)
        {
            //context.Semesters.AddOrUpdate(x => x.Id,
            //    new Semester() { Name = "Semester 1" },
            //    new Semester() { Name = "Semester 2" },
            //    new Semester() { Name = "Semester 3" },
            //    new Semester() { Name = "Semester 4" }
            //);
            //var courses = new List<Course>()
            //{
            //    new Course(){ Name = "Web Design for Everybody: Basics of Web Development & Coding", Price = 500, SemesterId = 1, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d2j5ihb19pt1hq.cloudfront.net/sdp_page/s12n_logos/webdesign.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Learn to Design and Create Websites. Build a responsive and accessible web portfolio using HTML5, CSS3, and JavaScript"},
            //    new Course(){ Name = "Full-Stack Web Development with React", Price = 700, SemesterId = 1, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/eb/cab7f07dd411e8991ff71ead974a6c/Slide1.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Build Complete Web and Hybrid Mobile Solutions. Master front-end web, hybrid mobile app and server-side development in four comprehensive courses."},
            //    new Course(){ Name = "HTML, CSS, and Javascript for Web Developers", Price = 800, SemesterId = 1, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/83/e258e0532611e5a5072321239ff4d4/jhep-coursera-course4.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "We will start from the ground up by learning how to implement modern web pages with HTML and CSS"},
            //    new Course(){ Name = "JavaScript, jQuery, and JSON", Price = 750, SemesterId = 1, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/78/bf51e094c211e78308116c229500da/WA4E_thumbnail_JS_1x1.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "It is assumed that learners have already taken the Building Web Applications and Building Database Applications in PHP courses in this specialization."},
            //    new Course(){ Name = "Programming Foundations with JavaScript, HTML and CSS", Price = 650, SemesterId = 1, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/1d/9ab6c01a0711e5aafd874ac89d7e65/digital-388075_1280.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Learn foundational programming concepts (e.g., functions, for loops, conditional statements) and how to solve problems like a programmer."},
            //    new Course(){ Name = "Java Programming and Software Engineering Fundamentals", Price = 900, SemesterId = 1, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d2j5ihb19pt1hq.cloudfront.net/sdp_page/s12n_logos/Duke_JavaProgrammingIntrotoSoftware_CM195522.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Explore a Career as a Software Engineer. Learn the basics of programming and software development"},
            //    new Course(){ Name = "Interactivity with JavaScript", Price = 850, SemesterId = 1, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/d7/216ee0502611e5ab137970bddb1c09/javascript_thumnail_1x1.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "The class will culminate in a  final project - the creation of an interactive HTML5 form that accepts and verifies input."},
            //    new Course(){ Name = "Full Stack Web and Multiplatform Mobile App Development", Price = 700, SemesterId = 1, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/a4/d69e204d3a11e7bd76e991b22caa52/HKUST_full-stack-banner.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Build Complete Web and Hybrid Mobile Solutions. Master front-end web, hybrid mobile app and server-side development in five comprehensive courses."},
            //    new Course(){ Name = "Python 3 Programming", Price = 550, SemesterId = 2, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/be/0ce870e9cb11e8b2d233b4be6a9cf3/pythonfluency_1x1_4.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Become a Fluent Python Programmer. Learn the fundamentals and become an independent programmer."},
            //    new Course(){ Name = "Google IT Automation with Python", Price = 600, SemesterId = 2, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/10/94e64625eb4b41b05e66ed0e5bab30/Xavier-MI-Thompson-119.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Learn in-demand skills like Python, Git, and IT automation to advance your career."},
            //    new Course(){ Name = "IBM Data Science", Price = 800, SemesterId = 2, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/ed/4131809fe511e8937a7926bc59e37f/Professional-Certificate---Data-Science---600x600---Blu-Text.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Kickstart your Career in Data Science & ML. Master data science, learn Python & SQL, analyze & visualize data, build machine learning models."},
            //    new Course(){ Name = "Applied Data Science with Python", Price = 950, SemesterId = 2, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/c8/8d6df01eb311e6b5f5f786b289d8ba/pythondatascience_specialization_final.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Gain new insights into your data . Learn to apply data science methods and techniques, and acquire analysis skills."},
            //    new Course(){ Name = "Programming for Everybody (Getting Started with Python)", Price = 550, SemesterId = 2, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/08/33f720502a11e59e72391aa537f5c9/pythonlearn_thumbnail_1x1.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "This course aims to teach everyone the basics of programming computers using Python."},
            //    new Course(){ Name = "Python I: Aprendiendo a programar Python", Price = 700, SemesterId = 2, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/bf/af25202b6411e7973bdddc08fd00dc/curso-python_V4.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "This introduction to Python will kickstart your learning of Python for data science, as well as programming in general."},
            //    new Course(){ Name = "Python for Data Science and AI", Price = 800, SemesterId = 2, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/79/192c002fe111e88780515c581bd11f/Screen-Shot-2018-03-24-at-4.42.07-PM.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "This course is designed to teach you the foundations in order to write simple programs in Python using the most common structures."},
            //    new Course(){ Name = "Python Basics", Price = 850, SemesterId = 2, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/77/17ca30e9cf11e8931fddf70eb768e1/pythonfluency_1x1_course_1.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "This course introduces the basics of Python 3, including conditional execution and iteration as control structures, and strings and lists as data structures. "},
            //    new Course(){ Name = "Open Source Software Development, Linux and Git", Price = 700, SemesterId = 3, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/93/ab9a20c81711e8888807689cc8fd41/Introduction-to-Open-Source-Software-Development_-Git-and-Linux.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Launch Your Android App Development Career. Master the knowledge and skills necessary to develop maintainable mobile computing apps"},
            //    new Course(){ Name = "Android App Development", Price = 750, SemesterId = 3, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/ca/bd3c40bb0811e5ba54dbc0616c905c/AAD-settings.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Learn How To Develop Open Source Software. Get the skills and knowledge you need to develop open source software using Linux, git, and more!"},
            //    new Course(){ Name = "Linux for Developers", Price = 850, SemesterId = 3, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/2c/b20780cc8d11e8ac2561fe7b0ecdea/Coursera-Specialization-Course-2-Header.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "How to separate the kernel from the entire operating system, making contributions to the kernel"},
            //    new Course(){ Name = "Linux Server Management and Security", Price = 800, SemesterId = 3, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/a0/abb270118c11e79b3c974b5149e3f3/3.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Whether you are accessing a bank website, Netflix or your home router, chances are that your computer is interacting with a Linux system"},
            //    new Course(){ Name = "Data Engineering with Google Cloud", Price = 750, SemesterId = 3, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/81/4f605ccfea4c3cb55626902b243a4a/Option-3_1.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Advance your career in data engineering and recommends training to support your preparation for the industry-recognized Google Cloud Professional Data Engineer certification."},
            //    new Course(){ Name = "Introduction to Cybersecurity Tools & Cyber Attacks", Price = 500, SemesterId = 3, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/a1/4d3f79658647c595a756fba0e715e8/hacker.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "The completion of this course also makes you eligible to earn the Introduction to Cybersecurity Tools & Cyber Attacks IBM digital badge."},
            //    new Course(){ Name = "Computer Communications", Price = 900, SemesterId = 3, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/07/1d85e07ec211e78ea8bdfc9d4b2d48/redes-informaticas.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Launch your career in computer network & security. Provide an introduction to fundamental network architecture concepts and network design alternatives"},
            //    new Course(){ Name = "Introduction to Big Data", Price = 700, SemesterId = 4, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/f0/2514c0659311e894d3e7ac680ef0c6/BD-Especialitzacio.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Mejora tu perfil profesional. BIG DATA: una de las disciplinas con mayor demanda de personal cualificado"},
            //    new Course(){ Name = "Modern Big Data Analysis with SQL", Price = 750, SemesterId = 4, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/e0/9258906e4b11e88932d773ab868ede/GettyImages-835871924_medium_cdaSpec_square.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Data Engineering on Google Cloud Platform. Launch your career in Data Engineering. Deliver business value with big data and machine learning."},
            //    new Course(){ Name = "Introduction to Data Science", Price = 800, SemesterId = 4, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/10/050240796d11e88ee4d58f19c7d422/Data-Science-Foundations-Logo-Draft-v3.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Learn Data Analysis for Big Data. Master using SQL for data analysis on distributed big data systems"},
            //    new Course(){ Name = "Big Data Essentials: HDFS, MapReduce and Spark RDD", Price = 850, SemesterId = 4, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/9c/890410a14511e792ff9736c18c3b68/Yandex-466_2.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Launch your career in Data Science. Data Science skills to prepare for a career or further advanced learning in Data Science."},
            //    new Course(){ Name = "Excel to MySQL: Analytic Techniques for Business", Price = 800, SemesterId = 4, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d2j5ihb19pt1hq.cloudfront.net/sdp_page/s12n_logos/Duke_ExceltoMySQLGetty529354813.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Learn some basic technologies of the modern Big Data landscape, namely: HDFS, MapReduce and Spark"},
            //    new Course(){ Name = "What is Data Science?", Price = 900, SemesterId = 4, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://s3.amazonaws.com/coursera-course-photos/16/d602b00a6c11e88d594f951694ab88/Data-Science-Orientation.png?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Turn Data Into Value. Drive business process change by identifying & analyzing key metrics in 4 industry-relevant courses."},
            //    new Course(){ Name = "Functional Programming in Scala", Price = 950, SemesterId = 4, Image = "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://d15cw65ipctsrr.cloudfront.net/ca/8934e0188711e69d2049c17d0d6907/twenty20_54db5e50-8425-4ffd-a4fd-8ba5b4813b9a.jpg?auto=format%2Ccompress&dpr=1&w=510&h=315&fit=crop", Description = "Processing large graphs with Spark GraphFrames, Debugging, profiling and optimizing Spark application performance."},
            //};
            //foreach (var course in courses)
            //{
            //    context.Courses.Add(course);
            //    context.SaveChanges();
            //}
            //var userManager = new UserManager<ApplicationUser>(
            //    new UserStore<ApplicationUser>(context));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //if (!roleManager.RoleExists("Admin"))
            //{
            //    var role = new IdentityRole("Admin");
            //    roleManager.Create(role);

            //}
            //if (!roleManager.RoleExists("Student"))
            //{
            //    var role = new IdentityRole("Student");
            //    roleManager.Create(role);

            //}
            //if (!context.Users.Any(u => u.UserName == "admin@gmail.com"))
            //{
            //    var user = new ApplicationUser
            //    {
            //        UserName = "admin@gmail.com",
            //        Email = "admin@gmail.com"
            //    };
            //    userManager.Create(user, "password");
            //    userManager.AddToRole(user.Id, "Admin");
            //}
            //if (!context.Users.Any(u => u.UserName == "student@gmail.com"))
            //{
            //    var user = new ApplicationUser
            //    {
            //        UserName = "student@gmail.com",
            //        Email = "student@gmail.com",
            //        Fullname = "StudentDemo",
            //        Address = "Ba Đình - Hà Nội",
            //        SemesterId = 1,
            //        Phone = "0123412349",
            //    };
            //    user.StudentCourses = new List<StudentCourse>()
            //    {
            //        new StudentCourse() {CourseId = 2, Point = 7, StudentId = user.Id},
            //        new StudentCourse() { CourseId = 3, Point = 8, StudentId = user.Id},
            //        new StudentCourse() { CourseId = 4, Point = 5, StudentId = user.Id}
            //    };
            //    userManager.Create(user, "password");
            //    userManager.AddToRole(user.Id, "Student");
            //}
            //var students = new List<Student>()
            //{
            //    new Student() { Fullname = "Đào Công Kiên", Address = "Hoàng Mai - Hà Nội", Phone = "0121213211", Email = "daocongkien@gmail.com", SemesterId = 1, StudentCourses = new List<StudentCourse>()
            //    {
            //        new StudentCourse(){CourseId = 2},
            //        new StudentCourse(){CourseId = 3}
            //    }},
            //    new Student() { Fullname = "Phạm Thanh Hoa", Address = "Thanh Trì - Hà Nội", Phone = "0125343211", Email = "phamthanhhoa@gmail.com", SemesterId = 1, StudentCourses = new List<StudentCourse>()
            //    {
            //        new StudentCourse(){CourseId = 2},
            //        new StudentCourse(){CourseId = 4}
            //    }},
            //    new Student() { Fullname = "Nguyễn Tuấn Anh", Address = "Hà Đông - Hà Nội", Phone = "0391213211", Email = "nguyentuananh@gmail.com", SemesterId = 1, StudentCourses = new List<StudentCourse>()
            //    {
            //        new StudentCourse(){CourseId = 2},
            //        new StudentCourse(){CourseId = 4}
            //    }},
            //    new Student() { Fullname = "Nguyễn Văn Đạt", Address = "Cầu Giấy - Hà Nội", Phone = "0197513211", Email = "nguyenvandat@gmail.com", SemesterId = 2},
            //    new Student() { Fullname = "Trần Ngọc Ánh", Address = "Nam Từ Liêm - Hà Nội", Phone = "0121213323", Email = "tranngocanh@gmail.com", SemesterId = 2},
            //    new Student() { Fullname = "Nguyễn Vân Anh", Address = "Ba Đình - Hà Nội", Phone = "0121213443", Email = "nguyenvananh@gmail.com", SemesterId = 3},
            //    new Student() { Fullname = "Hồ Quang Khải", Address = "Hoàng Mai - Hà Nội", Phone = "0121232356", Email = "hoquangkhai@gmail.com", SemesterId = 3},
            //    new Student() { Fullname = "Lê Xuân Bách", Address = "Cầu Giấy - Hà Nội", Phone = "0121213210", Email = "lexuanbach@gmail.com", SemesterId = 4},
            //    new Student() { Fullname = "Hoàng Tất Thành", Address = "Cầu Giấy - Hà Nội", Phone = "0121213887", Email = "hoangtatthanh@gmail.com", SemesterId = 4},
            //    new Student() { Fullname = "Bùi Thanh Phong", Address = "Ba Đình - Hà Nội", Phone = "0121213299", Email = "buithanhphong@gmail.com", SemesterId = 1},
            //    new Student() { Fullname = "Lê Thành Phát", Address = "Hà Đông - Hà Nội", Phone = "0981213211", Email = "lethanhphat@gmail.com", SemesterId = 2},
            //};
            //foreach (var student in students)
            //{
            //    if (!context.Users.Any(u => u.UserName == student.Email))
            //    {
            //        var user = new ApplicationUser
            //        {
            //            UserName = student.Email,
            //            Email = student.Email,
            //            Address = student.Address,
            //            Phone = student.Phone,
            //            Fullname = student.Fullname,
            //            SemesterId = student.SemesterId,
            //        };
            //        if (student.StudentCourses != null)
            //        {
            //            foreach (var sc in student.StudentCourses)
            //            {
            //                sc.StudentId = user.Id;

            //            }
            //            user.StudentCourses = student.StudentCourses;
            //        }
            //        userManager.Create(user, "password");
            //        userManager.AddToRole(user.Id, "Student");
            //    }
            //}
            //context.FAQs.AddOrUpdate(x => x.Id,
            //                new FAQ() { Question = "How to join the course?", Answer = "On this the admin should be able to enter or update the procedures for joining the course that the institute offers." },
            //                new FAQ() { Question = "Why to join the institute?", Answer = "The various benefits that the student can gain by joining the institution is to be provided." },
            //                new FAQ() { Question = "When will be Entrance Examinations Conducted?", Answer = "Once in 6 months, and one need to check the website for knowing when is the entrance exam entitled, the fees for the entrance exam (admin will decide and displayed on the application form), etc. are to be listed." },
            //                new FAQ() { Question = "Can I use the Lab facilities after my class hours? Will there be any extra hidden charges?", Answer = "Yes, you can use the lab sessions even after your class hours. There will be no charges during the course days (i.e., during the course period if you want to use the lab sessions after the class hours we do provide the lab session and the labs will be kept opened till 9 PM in the evening. But yes if you want to use the lab session after your course completion, then it will be charged based on the scenario (like 1000$ if opted at the time of registering and 1500$ if opted after the completion of the course." },
            //                new FAQ() { Question = "How can I apply for the entrance exam?", Answer = "Once the entrance exams are entitled, one need to visit the centre for applying it through paper and fill all the necessary details through online. On the application form one should chose which course he/she wanted to pursue." },
            //                new FAQ() { Question = "Will there be any fees for the entrance exam?", Answer = "Yes there will be and it will be available on the application form." },
            //                new FAQ() { Question = " How to make the payment?", Answer = "Payment can be done through draft, or through cheque or through cash. For making the payment through cash, one needs to come to one of the centre of the institute, and make the payment there itself. Once the payment is done (through cash or through DD), the student will be provided with the receipt with a receipt number. This receipt number is to be inputted in the application form. For the payments done through cheque and DD, one need to enter the DD number and the cheque number, bank details, etc. are to be entered on the application form and the cheque is to be pinned to the application form. Only once the payment is received the student’s application will be accepted. Once the application is accepted, the student is mailed with the acknowledgement form along with the details of the examination, subject chosen, date and time of exam, and the roll number." }
            //            );
            //context.CenterDetails.AddOrUpdate(x => x.Id,
            //    new CenterDetail() { Hotline = 0123456712, Name = "Sympony Limites" }
            //    );

            //List<Choice> listChoices = new List<Choice>()
            //{
            //    new Choice(){Id = 1, ChoiceContent = "A", IsRight = true},
            //    new Choice(){Id = 2, ChoiceContent = "B", IsRight = false},
            //    new Choice(){Id = 3, ChoiceContent = "C", IsRight = false},
            //    new Choice(){Id = 4, ChoiceContent = "D", IsRight = false},
            //};
            List<Question> listQuestions = new List<Question>()
            {
                new Question(){QuestionContent = "What are the key features in the C programming language?", CourseId = 2, Point = 1, AnswerContent = "The possibility of a programmer to control the language", Choices = new List<Choice>()
                {
                    new Choice(){ChoiceContent = "Possibility to break down large programs into small modules", IsRight = false},
                    new Choice(){ChoiceContent = "The possibility of a programmer to control the language", IsRight = true},
                    new Choice(){ChoiceContent = "Possibility to add new features by the programmer", IsRight = false},
                    new Choice(){ChoiceContent = "It is a platform-independent language", IsRight = false},
                }},
                new Question(){QuestionContent = "What are the modifiers available in C programming language?", CourseId = 2, Point = 1, AnswerContent = "Short", Choices = new List<Choice>()
                {
                    new Choice(){ChoiceContent = "Short", IsRight = true},
                    new Choice(){ChoiceContent = "Long", IsRight = false},
                    new Choice(){ChoiceContent = "Signed", IsRight = false},
                    new Choice(){ChoiceContent = "Unsigned", IsRight = false},
                }},
                new Question(){QuestionContent = "Which of the following is not the keyword in C++?", CourseId = 2, Point = 2, AnswerContent = "friend", Choices = new List<Choice>()
                {
                    new Choice(){ChoiceContent = "volatile", IsRight = false},
                    new Choice(){ChoiceContent = "friend", IsRight = true},
                    new Choice(){ChoiceContent = "extends", IsRight = false},
                    new Choice(){ChoiceContent = "this", IsRight = false},
                }},
                new Question(){QuestionContent = "C++ does not supports the following?", CourseId = 2, Point = 1, AnswerContent = "Hybrid inheritance", Choices = new List<Choice>()
                {
                    new Choice(){ChoiceContent = "Multilevel inheritance", IsRight = false},
                    new Choice(){ChoiceContent = "Hybrid inheritance", IsRight = true},
                    new Choice(){ChoiceContent = "None of the above", IsRight = false},
                    new Choice(){ChoiceContent = "Hierarchical inheritance", IsRight = false},
                }},
                new Question(){QuestionContent = "Which feature of the OOPS gives the concept of reusability?", CourseId = 3, Point = 1, AnswerContent = "Inheritance", Choices = new List<Choice>()
                {
                    new Choice(){ChoiceContent = "Abstraction", IsRight = false},
                    new Choice(){ChoiceContent = "Encapsulation", IsRight = false},
                    new Choice(){ChoiceContent = "Inheritance", IsRight = true},
                    new Choice(){ChoiceContent = "None of the above", IsRight = false},
                }},
                new Question(){QuestionContent = "The default executable generation on UNIX for a C++ program is ___", CourseId = 3, Point = 1, AnswerContent = "a.exe", Choices = new List<Choice>()
                {
                    new Choice(){ChoiceContent = "a.exe", IsRight = true},
                    new Choice(){ChoiceContent = "a", IsRight = false},
                    new Choice(){ChoiceContent = "a.out", IsRight = false},
                    new Choice(){ChoiceContent = "out.a", IsRight = false},
                }},
                new Question(){QuestionContent = "What is the full form of STL?", CourseId = 3, Point = 2, AnswerContent = "Standard template library", Choices = new List<Choice>()
                {
                    new Choice(){ChoiceContent = "Standard template library", IsRight = true},
                    new Choice(){ChoiceContent = "System template library", IsRight = false},
                    new Choice(){ChoiceContent = "Standard topics library", IsRight = false},
                    new Choice(){ChoiceContent = "None of the above", IsRight = false},
                }},
            };
            foreach (var question in listQuestions)
            {
                context.Question.AddOrUpdate(question);
            }
        }
    }
}
