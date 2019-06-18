using PrivateSchool.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool.Managers
{
    class HeadMaster:User
    {
        public static void HeadMasterMenu(HeadMaster headMaster, SqlConnection sqlConnection)
        {
            
            using (sqlConnection)
            {
                
                Console.WriteLine("Please choose: ");
                Console.WriteLine("1 for CRUD on Courses: ");
                Console.WriteLine("2 for CRUD on Students: ");
                Console.WriteLine("3 for CCRUD on Assignments");
                Console.WriteLine("4 for CCRUD on Trainers");
                Console.WriteLine("5 for CRUD on Students per Courses: ");
                Console.WriteLine("6 for CRUD on Trainers per Courses: ");
                Console.WriteLine("7 for CRUD on Assignments per Courses: ");
                Console.WriteLine("8 for CRUD on Schedule per Courses: ");
                int userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1://iCRUD on Courses

                        break;
                    case 2://ii.CRUD on Students
                        Console.WriteLine("1 To create student");
                        Console.WriteLine("2 To Read Student");
                        Console.WriteLine("3 To Update student");
                        Console.WriteLine("4 To Delete student");
                        int crudInput2 = Convert.ToInt32(Console.ReadLine());

                        switch (crudInput2)
                        {
                            case 1:
                                headMaster.RegisterStudent();
                                break;
                            case 2:
                                Console.WriteLine("Enter the student ID to Read: ");
                                int userInput1 = Convert.ToInt32(Console.ReadLine());
                                headMaster.ReadStudent(userInput1);
                                break;
                            case 3:
                                Console.WriteLine("Enter the student ID to Update: ");
                                int userInput2a = Convert.ToInt32(Console.ReadLine());
                                headMaster.UpdateStudent(userInput2a);

                                break;
                            case 4:
                                Console.WriteLine("Enter the student ID to Delete: ");
                                int userInput3 = Convert.ToInt32(Console.ReadLine());
                                headMaster.DeleteStudent(userInput3);
                                break;
                            default:
                                Console.WriteLine("Something Went Wrong - Please try again");

                                break;
                        }
                        break;

                    case 3://iii.CRUD on Assignments
                        break;
                    case 4: //iv. CRUD on Trainers
                        break;
                    case 5://v. CRUD on Students per Courses
                        Console.WriteLine("1 to add a student on a course");
                        Console.WriteLine("2 to view all course for a student");
                        Console.WriteLine("3 to change a student from a course");
                        Console.WriteLine("4 to remove a student from a course");
                        int crudInput5 = Convert.ToInt32(Console.ReadLine());

                        switch (crudInput5)
                        {
                            case 1:
                                Console.WriteLine("Enter the student id and the course id to add the student on the course");
                                Console.WriteLine("Enter student id");
                                int studentId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter course id");
                                int coursetId = Convert.ToInt32(Console.ReadLine());
                                headMaster.AddStudentToCourse(studentId, coursetId);
                                break;
                            case 2:
                                Console.WriteLine("Enter the student id to view all the student course");
                                Console.WriteLine("Enter student id");
                                int studentId2 = Convert.ToInt32(Console.ReadLine());
                                //headMaster.AllCoursePerStudent(studentId2);
                                break;
                            case 3:
                                Console.WriteLine("Enter the student id and the course id to change the student from the course");
                                Console.WriteLine("Enter student id");
                                int studentId3 = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter the old course id");
                                int coursetId3 = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter the new course id");
                                int coursetId4 = Convert.ToInt32(Console.ReadLine());
                                headMaster.ChangeStrudentFromCourse(studentId3, coursetId3, coursetId4);
                                break;
                            case 4:
                                Console.WriteLine("Enter the student id and the course id to delete the student from the course");
                                Console.WriteLine("Enter student id");
                                int studentId5 = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter course id");
                                int coursetId5 = Convert.ToInt32(Console.ReadLine());
                                headMaster.DeleteStudentFromCourse(studentId5, coursetId5);
                                break;
                            default:
                                Console.WriteLine("Something Went Wrong - Please try again");
                                break;
                        }
                        break;
                    case 6://vi. CRUD on Trainers per Courses
                        break;
                    case 7://vii. CRUD on Assignments per Courses
                        break;
                    case 8://viii. CRUD on Schedule per Courses
                        break;
                    default:
                        Console.WriteLine("Something Went Wrong - Please try again");
                        break;
                } 
            }
        }

        /// <summary>
        /// Methods to ii.CRUD on Students
        /// </summary>
        public void RegisterStudent()
        {
            // Create a Student
            Console.WriteLine("Enter UserName");
            string inputUsername = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string inputPassword = Console.ReadLine();
            Console.WriteLine("Enter First");
            string inputFirst = Console.ReadLine();
            Console.WriteLine("Enter LastName");
            string inputLastName = Console.ReadLine();
            Console.WriteLine("Enter DateOfBirth");
            string inputDateOfBirth = Console.ReadLine();
            Console.WriteLine("Enter TuitionFee");
            string inputTuitionFee = Console.ReadLine();
            int newUserRole = (int)Role.student;

            Auth.sqlConnection.Open();
            SqlCommand regUser = new SqlCommand($"INSERT INTO Users(UserName,DateOfBirth,TuitionFee,Password,FirstName,LastName,Roles) VALUES ('{inputUsername}', '{inputDateOfBirth}','{inputTuitionFee}','{inputPassword}','{inputFirst}','{inputLastName}','{newUserRole}')", Auth.sqlConnection);
            regUser.ExecuteNonQuery();
            Auth.sqlConnection.Close();
        }

        public void ReadStudent(int ID)
        {
            Auth.sqlConnection.Open();
            SqlCommand userRead = new SqlCommand($"Select FirstName,LastName,DateOfBirth,TuitionFee FROM Users WHERE id = '{ID}' and Roles = '1'", Auth.sqlConnection);
            SqlDataReader Reader = userRead.ExecuteReader();
            Reader.Read();

            // crete a Student Object
            Student student = new Student();
            student.FirstName = Reader.GetString(0);
            student.LastName = Reader.GetString(1);
            student.DateOfBirthday = Reader.GetDateTime(2);
            student.TuitionFee = Reader.GetDecimal(3);

            // Print Student
            Console.WriteLine($"Student Name : {student.FirstName} {student.LastName} Date of Birthday: {student.DateOfBirthday.ToString()} Tuition: {student.TuitionFee.ToString()}");
            Console.ReadKey();

            Reader.Close();
            Auth.sqlConnection.Close();
        }

        public void UpdateStudent(int ID)
        {
            Console.WriteLine("Enter FirstName");
            string inputFirstName = Console.ReadLine();
            Console.WriteLine("Enter LastName");
            string inputLastName = Console.ReadLine();
            Console.WriteLine("Enter UserName");
            string inputUserName = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string inputPassword = Console.ReadLine();
            Console.WriteLine("Enter DateOfBirth");
            string inputDateOfBirth = Console.ReadLine();
            Console.WriteLine("Enter TuitionFee");
            string inputTuitionFee = Console.ReadLine();


            Auth.sqlConnection.Open();
            SqlCommand UpdateStudent = new SqlCommand($"UPDATE Users SET FirstName = '{inputFirstName}', LastName ='{inputLastName}', UserName = '{inputUserName}', Password = '{inputPassword}', DateOfBirth = '{inputDateOfBirth}', TuitionFee = '{inputTuitionFee}'  WHERE id = '{ID}'", Auth.sqlConnection);
            UpdateStudent.ExecuteNonQuery();
            Auth.sqlConnection.Close();
        }

        public void DeleteStudent(int ID)
        {
            Auth.sqlConnection.Open();
            SqlCommand DeleteStudent = new SqlCommand($"DELETE FROM Users WHERE id = {ID}", Auth.sqlConnection);
            DeleteStudent.ExecuteNonQuery();
            Auth.sqlConnection.Close();
        }

        /// <summary>
        /// Method to v.CRUD on Students per Courses
        /// </summary>
        /// 
        public void AddStudentToCourse(int StudentID,int CourseID)
        {
            Auth.sqlConnection.Open();
            SqlCommand AddStudentToCourse = new SqlCommand($"INSERT INTO User_Courses SET UserID = '{StudentID}', CourseID ='{CourseID}'", Auth.sqlConnection);
            AddStudentToCourse.ExecuteNonQuery();
            Auth.sqlConnection.Close();
        }

        //public void AllCoursePerStudent(int StudentID)
        //{
        //    Auth.sqlConnection.Open();
        //    //SqlCommand AllCoursePerStudent = new SqlCommand($"SELECT CourseID FROM User_Courses AND Courses WHERE UserID = '{StudentID}'", Auth.sqlConnection);
        //    //SqlCommand AllCoursePerStudent = new SqlCommand($"SELECT DISTINCT CourseID FROM User_Courses,Courses WHERE UserID = '{StudentID}'", Auth.sqlConnection);
        //    SqlCommand AllCoursePerStudent = new SqlCommand($"SELECT DISTINCT Title,IsFullTime,MainSubject,StartDate,EndDate,TrainerID FROM User_Courses, Courses, Users WHERE UserID = '{StudentID}' ", Auth.sqlConnection);

        //    SqlDataReader readerUsers = AllCoursePerStudent.ExecuteReader();
        //    List<Course> courses = new List<Course>();

        //    while (readerUsers.Read())
        //    {
        //        //int trainerid = readerUsers.GetInt32(5);
        //        //SqlCommand findTrainer = new SqlCommand($"SELECT User.FirstName,User.LastName FROM Users WHERE UserID = '{trainerid}'", Auth.sqlConnection);
        //        //SqlDataReader theTrainer = findTrainer.ExecuteReader();
        //        //Trainer trainer = new Trainer()
        //        //{
        //        //    FirstName = theTrainer.GetString(0),
        //        //    LastName = theTrainer.GetString(0),
        //        //};
        //        //Console.WriteLine(trainer.FirstName + " " + trainer.LastName);


        //        Course course = new Course()
        //        {
        //            Title = readerUsers.GetString(0),
        //            IsFullTime = Convert.ToBoolean(readerUsers.GetByte(1)),
        //            MainSubject = (Subject)readerUsers.GetInt32(2),
        //            StartDate = readerUsers.GetDateTime(3),
        //            EndDate = readerUsers.GetDateTime(4),
        //            //Trainer = trainer;
        //        };
        //        courses.Add(course);
        //    }
            
        //    readerUsers.Close();
        //    Auth.sqlConnection.Close();

        //    foreach (Course course in courses)
        //    {
        //        Console.WriteLine(course);
        //    }
        //}
        public void ChangeStrudentFromCourse(int StudentID, int OldCourseID, int NewCourseID)
        {
            Auth.sqlConnection.Open();
            SqlCommand ChangeStrudentFromCourse = new SqlCommand($"UPDATE User_Courses SET CourseID ='{NewCourseID}'  WHERE UserID = '{StudentID}' and CourseID = '{OldCourseID}'", Auth.sqlConnection);
            ChangeStrudentFromCourse.ExecuteNonQuery();
            Auth.sqlConnection.Close();
        }
        public void DeleteStudentFromCourse(int StudentID, int CourseID)
        {
            Auth.sqlConnection.Open();
            SqlCommand DeleteStudentFromCourse = new SqlCommand($"DELETE FROM User_Courses WHERE CourseID = {CourseID} and UserID = '{StudentID}'", Auth.sqlConnection);
            DeleteStudentFromCourse.ExecuteNonQuery();
            Auth.sqlConnection.Close();
        }
    }
}
