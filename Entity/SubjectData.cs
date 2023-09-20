using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace assessment
{
    public class SubjectData
    {

        public static List<Subject> Subjects { get; } = new List<Subject>
    {
        new Subject { code = "1103", name = "Bahasa Melayu" },
        new Subject { code = "1119", name = "Bahasa Inggeris" },
        new Subject { code = "1223", name = "Pendidkan Islam" },
        new Subject { code = "1225", name = "Pendidkan Moral" },
        new Subject { code = "1249", name = "Sejarah" },
        new Subject { code = "1449", name = "Mathematics" },
        new Subject { code = "1511", name = "Science" },
        new Subject { code = "2611", name = "Pendidikan Seni Visual" },
        new Subject { code = "3472", name = "Additional Mathematics" },
        new Subject { code = "4531", name = "Physics" },
        new Subject { code = "4541", name = "Chemistry" },
        new Subject { code = "4551", name = "Biology" },
        new Subject { code = "4561", name = "Additional Science" },
        new Subject { code = "6351", name = "Bahasa Cina" },
        new Subject { code = "6354", name = "Bahasa Tamil" },
        new Subject { code = "3756", name = "Prinsip Perakaunan" },
        new Subject { code = "3767", name = "Ekonomi" },
        // Add more Subjects as needed
    };

        public static string getCoursename(string coursecode)
        {
            var subject = Subjects.FirstOrDefault(c => c.code == coursecode);
            if (subject != null)
            {
                return subject.name;
            }
            else
            {
                return null; // Handle the case where the course code is not found.
            }
        }
    }
}