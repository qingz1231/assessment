using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assessment
{
    public class Application
    {
        public int ApplicationID { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantIC { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string status { get; set; }
        public byte[] result { get; set; }

        
    }
}