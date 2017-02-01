using MimoChallengeBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MimoChallengeBackend.DAL
{
    public class MimoInitializer : System.Data.Entity.CreateDatabaseIfNotExists<MimoContext>
    {
        protected override void Seed(MimoContext context)
        {
            var users = new List<User>
            {
            new User{Name="Karim",Login="karim",Password="password"}
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
            var courses = new List<Course>
            {
            new Course{Title="C#",Description="xxx",},
            new Course{Title="Javascript",Description="xxx",},
            new Course{Title="Swift",Description="xxx",}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
            var chapters = new List<Chapter>
            {
            new Chapter{CourseID =1, Order=1, Title="Chapter 1", Description="xxx",},
            new Chapter{CourseID =1, Order=2, Title="Chapter 2", Description="xxx",},
            new Chapter{CourseID =1, Order=3, Title="Chapter 3", Description="xxx",},
            new Chapter{CourseID =1, Order=4, Title="Chapter 4", Description="xxx",},
            new Chapter{CourseID =1, Order=5, Title="Chapter 5", Description="xxx",},
            new Chapter{CourseID =2, Order=1, Title="Chapter 1", Description="xxx",},
            new Chapter{CourseID =2, Order=2, Title="Chapter 2", Description="xxx",},
            new Chapter{CourseID =2, Order=3, Title="Chapter 3", Description="xxx",},
            new Chapter{CourseID =2, Order=4, Title="Chapter 4", Description="xxx",},
            new Chapter{CourseID =2, Order=5, Title="Chapter 5", Description="xxx",},
            new Chapter{CourseID =3, Order=1, Title="Chapter 1", Description="xxx",},
            new Chapter{CourseID =3, Order=2, Title="Chapter 2", Description="xxx",},
            new Chapter{CourseID =3, Order=3, Title="Chapter 3", Description="xxx",},
            new Chapter{CourseID =3, Order=4, Title="Chapter 4", Description="xxx",},
            new Chapter{CourseID =3, Order=5, Title="Chapter 5", Description="xxx",}
            };
            chapters.ForEach(s => context.Chapters.Add(s));
            context.SaveChanges();
            var lessons = new List<Lesson>
            {
            new Lesson{ChapterID =1, Title="Lesson 1", Desc="xxx", Order=1,},
            new Lesson{ChapterID =1, Title="Lesson 2", Desc="xxx", Order=2},
            new Lesson{ChapterID =1, Title="Lesson 3", Desc="xxx", Order=3},
            new Lesson{ChapterID =2, Title="Lesson 1", Desc="xxx", Order=1},
            new Lesson{ChapterID =2, Title="Lesson 2", Desc="xxx", Order=2},
            new Lesson{ChapterID =2, Title="Lesson 3", Desc="xxx", Order=3},
            new Lesson{ChapterID =3, Title="Lesson 1", Desc="xxx", Order=1},
            new Lesson{ChapterID =3, Title="Lesson 2", Desc="xxx", Order=2},
            new Lesson{ChapterID =3, Title="Lesson 3", Desc="xxx", Order=3},
            new Lesson{ChapterID =4, Title="Lesson 1", Desc="xxx", Order=1},
            new Lesson{ChapterID =4, Title="Lesson 2", Desc="xxx", Order=2},
            new Lesson{ChapterID =4, Title="Lesson 3", Desc="xxx", Order=3},
            new Lesson{ChapterID =5, Title="Lesson 1", Desc="xxx", Order=1},
            new Lesson{ChapterID =5, Title="Lesson 2", Desc="xxx", Order=2},
            new Lesson{ChapterID =5, Title="Lesson 3", Desc="xxx", Order=3},
            new Lesson{ChapterID =6, Title="Lesson 1", Desc="xxx", Order=1},
            new Lesson{ChapterID =6, Title="Lesson 2", Desc="xxx", Order=2},
            new Lesson{ChapterID =6, Title="Lesson 3", Desc="xxx", Order=3},
            new Lesson{ChapterID =7, Title="Lesson 1", Desc="xxx", Order=1},
            new Lesson{ChapterID =7, Title="Lesson 2", Desc="xxx", Order=2},
            new Lesson{ChapterID =7, Title="Lesson 3", Desc="xxx", Order=3},
            new Lesson{ChapterID =8, Title="Lesson 1", Desc="xxx", Order=1},
            new Lesson{ChapterID =8, Title="Lesson 2", Desc="xxx", Order=2},
            new Lesson{ChapterID =8, Title="Lesson 3", Desc="xxx", Order=3},
            new Lesson{ChapterID =9, Title="Lesson 1", Desc="xxx", Order=1},
            new Lesson{ChapterID =9, Title="Lesson 2", Desc="xxx", Order=2},
            new Lesson{ChapterID =9, Title="Lesson 3", Desc="xxx", Order=3},
            new Lesson{ChapterID =10, Title="Lesson 1", Desc="xxx", Order=1},
            new Lesson{ChapterID =10, Title="Lesson 2", Desc="xxx", Order=2},
            new Lesson{ChapterID =10, Title="Lesson 3", Desc="xxx", Order=3},
            new Lesson{ChapterID =11, Title="Lesson 1", Desc="xxx", Order=1},
            new Lesson{ChapterID =11, Title="Lesson 2", Desc="xxx", Order=2},
            new Lesson{ChapterID =11, Title="Lesson 3", Desc="xxx", Order=3},
            new Lesson{ChapterID =12, Title="Lesson 1", Desc="xxx", Order=1},
            new Lesson{ChapterID =12, Title="Lesson 2", Desc="xxx", Order=2},
            new Lesson{ChapterID =12, Title="Lesson 3", Desc="xxx", Order=3},
            new Lesson{ChapterID =13, Title="Lesson 1", Desc="xxx", Order=1},
            new Lesson{ChapterID =13, Title="Lesson 2", Desc="xxx", Order=2},
            new Lesson{ChapterID =13, Title="Lesson 3", Desc="xxx", Order=3},
            new Lesson{ChapterID =14, Title="Lesson 1", Desc="xxx", Order=1},
            new Lesson{ChapterID =14, Title="Lesson 2", Desc="xxx", Order=2},
            new Lesson{ChapterID =14, Title="Lesson 3", Desc="xxx", Order=3},
            new Lesson{ChapterID =15, Title="Lesson 1", Desc="xxx", Order=1},
            new Lesson{ChapterID =15, Title="Lesson 2", Desc="xxx", Order=2},
            new Lesson{ChapterID =15, Title="Lesson 3", Desc="xxx", Order=3},
            };
            lessons.ForEach(s => context.Lessons.Add(s));
            context.SaveChanges();
        }
    }
}