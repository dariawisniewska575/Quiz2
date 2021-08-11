using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz
{
    public class scoreClass
    {
        public string Name {get;set;}
        public string Points { get; set; }
        public scoreClass()
        {
            Name = "";
            Points = "";
        }
        public  scoreClass(string name, string points)
        {
            Name = name;
            Points = points;
        }
    }
}
