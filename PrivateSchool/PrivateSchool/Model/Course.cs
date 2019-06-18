using PrivateSchool.Managers;
using PrivateSchool.Model.MiddleClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool.Model
{
    enum Subject
    {
        java=1,
        python,
        C,
        c_sharp
            
    }
    class Course
    {
        public int id { get; set; }
        public string Title { get; set; }
        public Subject MainSubject { get; set; }
        public bool IsFullTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<UserCourse> Students { get; set; }
        public Trainer Trainer { get; set; }


    }
}
