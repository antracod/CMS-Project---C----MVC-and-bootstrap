using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMN.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }
    }
}