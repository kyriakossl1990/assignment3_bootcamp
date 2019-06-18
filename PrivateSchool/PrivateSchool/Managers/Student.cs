using PrivateSchool.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool.Managers
{
    class Student:User
    {
        public static void StudentMenu(int ID, Student student, SqlConnection sqlConnection)
        {
            using (sqlConnection)
            {
                Console.WriteLine("1 to See your daily Schedule per Course");
                Console.WriteLine("2 to See the dates of submission of the Assignments per Course");
                Console.WriteLine("3 Submit Assignments");
                int inputUser = Convert.ToInt32(Console.ReadLine());

                switch (inputUser)
                {
                    case 1://i.See his / her daily Schedule per Course
                        student.SeeDailySchedule(ID);
                        break;
                    case 2://ii.See the dates of submission of the Assignments
                        student.AssigmnetPerStudent(ID);
                        break;
                    case 3://iii. Submit any Assignments
                        student.SubmitAssignment(ID);
                        break;
                    default:
                        Console.WriteLine("Something Went Wrong - Please try again");
                        break;
                }
            }
        }
        /// <summary>
        /// Methods to  i.See his / her daily Schedule per Course
        /// </summary>
        public void SeeDailySchedule(int ID)
        {

        }

        /// <summary>
        /// Methods to  ii.See the dates of submission of the Assignments per Course
        /// </summary>
        public void AssigmnetPerStudent(int ID)
        {
            Auth.sqlConnection.Open();
            SqlCommand AssigmnetPerCourse = new SqlCommand($"SELECT DISTINCT id,Title,SubmissionDate,isSubmitted,Description FROM User_Assigments,Assigments WHERE UserID = '{ID}'", Auth.sqlConnection);
            SqlDataReader ReaderAssigmnetPerCourse = AssigmnetPerCourse.ExecuteReader();
            List<Assigment> assigments = new List<Assigment>();
            while (ReaderAssigmnetPerCourse.Read())
            {
                // Create each assigment object
                Assigment assigment = new Assigment
                {
                    id = ReaderAssigmnetPerCourse.GetInt32(0),
                    Title = ReaderAssigmnetPerCourse.GetString(1),
                    SubmitionDate = ReaderAssigmnetPerCourse.GetDateTime(2),
                    IsSubmitted= ReaderAssigmnetPerCourse.GetBoolean(3),
                    Description =ReaderAssigmnetPerCourse.GetString(4)
                };
                assigments.Add(assigment);
                
                // Print each assigment object
                foreach (Assigment a in assigments)
                {
                    //if (a.IsSubmitted)
                    //{
                    //    SqlCommand AssigmnetMark = new SqlCommand($"SELECT OralMark,TotalMark FROM Assigments WHERE id = '{a.id}'", Auth.sqlConnection);
                    //    SqlDataReader ReaderAssigmnetMark = AssigmnetMark.ExecuteReader();

                    //    a.OralMark = ReaderAssigmnetMark.GetInt32(0);
                    //    a.TotalMark = ReaderAssigmnetMark.GetInt32(1);
                    //    Console.WriteLine($"Assigmnet id: {a.id} - Assigmnet Title: {a.Title} - Oral Mark is: {a.OralMark} - Total Mark is: {a.TotalMark}");
                    //}

                    //else
                    //Console.WriteLine($"Assigmnet id: {a.id} - Assigmnet Title: {a.Title} - Assigmnet Submission Date is: {a.SubmitionDate}");

                    Console.WriteLine($"Assigmnet id: {a.id} - Assigmnet Title: {a.Title} - Assigmnet Description: {a.Description} - Assigmnet Submission Date is: {a.SubmitionDate}");
                    Console.ReadKey();
                }
            }
            ReaderAssigmnetPerCourse.Close();
            Auth.sqlConnection.Close();
            
        }
        /// <summary>
        /// Methods to iii. Submit any Assignments
        /// </summary>
        public void SubmitAssignment(int ID)
        {

        }
    }
}
