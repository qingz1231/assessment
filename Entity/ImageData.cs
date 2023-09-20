using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assessment
{
    public class ImageData
    {
        public string text { get; set; }
        public BoundingBox boundingBox { get; set; }


        public override string ToString()
        {
            return $"Text: {text}, BoundingBox: {boundingBox}";
        }
    }
}