using PrivateSchool.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool.Managers
{
    class Trainer : User
    {
        public static void TrainerMenu(int ID, Trainer trainer, SqlConnection sqlConnection)
        {
            using (sqlConnection)
            {
                Console.WriteLine("View all the Courses you enrolled");
                Console.WriteLine("View all the Students per Course");
                Console.WriteLine("View all the Assignments per Student per Course");
                Console.WriteLine("Mark all the Assignments per Student per Course");
                int userChoise = Convert.ToInt32(Console.ReadLine());

                switch (userChoise)
                {
                    case 1://i.View all the Courses he / she is enrolled
                        trainer.ViewAllCourses(ID);
                        break;
                    case 2://ii. View all the Students per Course
                        Console.WriteLine("Enter the student ID:");
                        int userChoise2 = Convert.ToInt32(Console.ReadLine());
                        trainer.AllStudentPerCourse(userChoise2);
                        break;
                    case 3://iii.View all the Assignments per Student per Course
                        Console.WriteLine("Enter Course ID: ");
                        int userChoise3 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Student ID: ");
                        int userChoise4 = Convert.ToInt32(Console.ReadLine());
                        trainer.AllAssignmentsPerStudentPerCourse(userChoise3, userChoise4);
                        break;
                    case 4: //iv.Mark all the Assignments per Student per Course
                        break;
                    default:
                        Console.WriteLine("Something Went Wrong - Please try again");
                        break;
                }

            }
        }
        /// <summary>
        /// Methods to View all the Courses he / she is enrolled
        /// </summary>
        /// <param name="TrainerID"></param>
        public void ViewAllCourses(int TrainerID)
        {
            Auth.sqlConnection.Open();
            SqlCommand userRead = new SqlCommand($"Select DISTINCT id,Title,MainSubject,StartDate,EndDate FROM Courses,User_Courses WHERE TrainerID = '{TrainerID}'", Auth.sqlConnection);
            SqlDataReader Reader = userRead.ExecuteReader();
            List<Course>AllCourses = new List<Course>();
            while (Reader.Read())
            {
                // Create a Course Object
                Course course = new Course()
                {
                    id = Reader.GetInt32(0),
                    Title = Reader.GetString(1),
                    MainSubject = (Subject)Reader.GetInt32(2),
                    StartDate = Reader.GetDateTime(3),
                    EndDate = Reader.GetDateTime(4)
                };
                AllCourses.Add(course);
            }

            // Print Courses
            foreach (Course c in AllCourses)
            {
                Console.WriteLine($"Course ID: {c.id} Title: {c.Title} Main Subjset: { c.MainSubject} Full Time: {c.IsFullTime} Start Date:  {c.StartDate}  End Date:  {c.EndDate}");
            }
            Console.ReadKey();

            Reader.Close();
            Auth.sqlConnection.Close();
        }
        /// <summary>
        /// Methods to View all the Students per Course
        /// </summary>
        
        public void AllStudentPerCourse(int StudentID)
        {

        }

        /// <summary>
        /// Methods to Mark all the Assignments per Student per Course
        /// </summary>

        public void AllAssignmentsPerStudentPerCourse(int CourseID,int StudentID)
        {

        }


    }
}
