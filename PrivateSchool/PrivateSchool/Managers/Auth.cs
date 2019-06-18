using PrivateSchool.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool.Managers
{
    class Auth
    {
        static string connectionString = @" Server = sql6007.site4now.net; Database = DB_A490A5_school; User id = DB_A490A5_school_admin;Password = Asdfghjkl7; MultipleActiveResultSets=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);

        public static void Welcome()
        {
            using (sqlConnection)
            {
                Console.WriteLine("Welcome");
                Console.WriteLine("Please Log in to your account");
                User user = new User();
                user = Login();
                int userAccess = (int)user.Role;

                switch (userAccess)
                {
                    case 1:// StrudentMenu
                        Console.WriteLine("You are student");
                        Student.StudentMenu(user.id, new Student(),sqlConnection);
                        break;
                    case 2:// TrainerMenu
                        Console.WriteLine("You are Trainer");
                        Trainer.TrainerMenu(user.id,new Trainer(),sqlConnection);
                        break;
                    case 3:// HeadMasterMenu
                        Console.WriteLine("You are HeadMaster");
                        HeadMaster.HeadMasterMenu(new HeadMaster(),sqlConnection);
                        break;
                    default:
                        Console.WriteLine("Something Went Wrong - Please try again");
                        break;
                }
            }
        }
        public static User Login()
        {
            sqlConnection.Open();
            Console.WriteLine("Please enter your username: ");
            string inputUsername = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            string inputPassword = Console.ReadLine();

            // Check if credential are correct
            SqlCommand userLogin = new SqlCommand($"Select Username,Password FROM Users WHERE Username = '{inputUsername}' and Password = '{inputPassword}'", sqlConnection);
            SqlDataReader Reader = userLogin.ExecuteReader();
            
            if (Reader.Read())
                Console.WriteLine("Successfully Logged in");
            else
            {
                Console.WriteLine("Something went wrong, please try again.");
                Login();
            }
            Reader.Close();

            // crete a User Object to return id and role
            User user = new User();
            user.id = findId(inputUsername, inputPassword);
            user.Role = findRole(inputUsername, inputPassword);
            sqlConnection.Close();
            return user;
            }

        public static int findId(string userName, string Password)
        {
            //Get user ID
            SqlCommand findAll = new SqlCommand($"SELECT id FROM Users WHERE Username = '{userName}' and password = '{Password}'", sqlConnection);
            SqlDataReader Reader = findAll.ExecuteReader();

            Reader.Read();
            int userId = Reader.GetInt32(0);
            return userId;
        }
        public static Role findRole(string userName, string Password)
        {
            //Get user Role
            SqlCommand findAll = new SqlCommand($"SELECT Roles FROM Users WHERE Username = '{userName}' and password = '{Password}'", sqlConnection);
            SqlDataReader Reader = findAll.ExecuteReader();

            Reader.Read();
            Role userRole = (Role)Reader.GetInt32(0);
            return userRole;
        }
    }
}

