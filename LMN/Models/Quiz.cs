using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMN.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool solvable { get; set; }
    }
}