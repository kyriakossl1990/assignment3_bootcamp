using PrivateSchool.Model.MiddleClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool.Model
{
    public enum Role
    {
        student =1,
        Trainer,
        HeadMaster
    }
    class User
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public decimal TuitionFee { get; set; }
        public Role Role { get; set; }
        public string Subject {get;set;}
        public List<Course> EnrolledCourses { get; set; }
    }
}
