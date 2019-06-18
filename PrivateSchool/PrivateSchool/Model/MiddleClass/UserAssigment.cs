using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool.Model.MiddleClass
{
    class UserAssigment
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int AssigmentId { get; set; }
        public Assigment Assigment { get; set; }
    }
}
