using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool.Model
{
    class Assigment
    {
        public int id { get; set; }
        public int OralMark { get; set; }
        public int TotalMark { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SubmitionDate { get; set; }
        public bool IsSubmitted { get; set; }

    }
}
