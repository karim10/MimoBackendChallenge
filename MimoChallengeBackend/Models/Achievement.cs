using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MimoChallengeBackend.Models
{
    public class Achievement
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int LessonID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public virtual User User { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}