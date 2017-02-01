using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MimoChallengeBackend.Models
{
    public class Chapter
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool achieved { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}