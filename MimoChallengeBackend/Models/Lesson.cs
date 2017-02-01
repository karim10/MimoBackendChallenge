using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MimoChallengeBackend.Models
{
    public class Lesson
    {
        public int ID { get; set; }
        public int ChapterID { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public int Order { get; set; }
        public bool achieved { get; set; }

        public virtual Chapter Chapter { get; set; }
    }
}