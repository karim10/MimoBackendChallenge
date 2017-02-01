using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MimoChallengeBackend.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool achieved { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
    }
}