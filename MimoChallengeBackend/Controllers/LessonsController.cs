using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MimoChallengeBackend.DAL;
using MimoChallengeBackend.Models;
using System.Diagnostics;

namespace MimoChallengeBackend.Controllers
{
    public class LessonsController : Controller
    {
        private MimoContext db = new MimoContext();
        public static DateTime start;
        public DateTime end;
        // GET: Lessons
        public ActionResult Index(int id)
        {
            var lessons = db.Lessons.Where(l => l.Chapter.ID == id);
            Chapter Chapter = db.Chapters.Find(id);
            Course Course = db.Courses.Find(Chapter.CourseID);
            List<Achievement> Achievements = new List<Achievement>();
            foreach (Lesson l in lessons)
            {
                Achievement Achievement =
                  (from ach in db.Achievements
                   where ach.LessonID == l.ID && ach.UserID == 1
                   select ach).FirstOrDefault();
                if (Achievement!=null)
                Achievements.Add(Achievement);
            }
            ViewBag.Chapter = Chapter.Title;
            ViewBag.Course = Course.Title;
            ViewBag.Achievements = Achievements;
            return View(lessons.ToList());
        }

        public ActionResult LessonAchieved(int id)
        {
            end = DateTime.Now;
            Achievement ach = new Achievement
            {
                UserID = 1,
                LessonID = id,
                StartTime = start.ToString(),
                EndTime = end.ToString()
            };
            db.Achievements.Add(ach);
            Lesson l =
                (from les in db.Lessons
                where les.ID == id
                select les).SingleOrDefault();
            l.achieved = true;
            update_lesson_column(l);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = l.ChapterID });
        }
        public void update_lesson_column(Lesson l)
        {
            List<Lesson> lessons = (from less in db.Lessons
                                    where less.ChapterID == l.ChapterID
                                    select less).ToList();
            bool chapter_achieved = true ;
            foreach (Lesson les in lessons)
            {
                if (les.achieved == false)
                    chapter_achieved = false;
                    
            }
            if (chapter_achieved)
            {
                Chapter chap =
                  (from chapter in db.Chapters
                   where chapter.ID == l.ChapterID
                   select chapter).SingleOrDefault();
               chap.achieved = true;
            }
            List<Chapter> chapters = (from chap in db.Chapters
                                    where chap.CourseID == l.Chapter.CourseID
                                    select chap).ToList();
            bool course_achieved = true;
            foreach (Chapter chap in chapters)
            {
                if (chap.achieved == false)
                    course_achieved = false;

            }
            if (course_achieved)
            {
                Course cour =
                  (from course in db.Courses
                   where course.ID == l.Chapter.CourseID
                   select course).SingleOrDefault();
                cour.achieved = true;
            }
        }
        // GET: Lessons/Details/5
        public ActionResult Details(int? id)
        {
            start = DateTime.Now;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // GET: Lessons/Create
        public ActionResult Create()
        {
            ViewBag.ChapterID = new SelectList(db.Chapters, "ID", "Title");
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ChapterID,Title,Desc,Order")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Lessons.Add(lesson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChapterID = new SelectList(db.Chapters, "ID", "Title", lesson.ChapterID);
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChapterID = new SelectList(db.Chapters, "ID", "Title", lesson.ChapterID);
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ChapterID,Title,Desc,Order")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lesson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChapterID = new SelectList(db.Chapters, "ID", "Title", lesson.ChapterID);
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lesson lesson = db.Lessons.Find(id);
            db.Lessons.Remove(lesson);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
