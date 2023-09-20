using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assessment
{
    public class BoundingBox
    {
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }

        public override string ToString()
        {
            return $"x1: {x1}, y1: {y1}, x2: {x2}, y2: {y2}";
        }
    }
}