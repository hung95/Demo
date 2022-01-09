using Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Helper
{
    public class MenuHelper
    {
        /// <summary>
        /// Display the main menu
        /// </summary>
        /// <returns>Menu Selection</returns>
        public static int ShowMainMenu()
        {
            int choice;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("Welcome to User List Manager");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write(
                "Please enter your choice: \n\n" +
                "[0] Add new user. \n" +
                "[1] Show users list. \n" +
                "[2] Update user info (by ID). \n" +
                "[3] Delete user (by ID). \n" +
                "[4] Exit. \n");
            Console.WriteLine("-------------------------------");

            var entry = Console.ReadLine();
            if (!int.TryParse(entry, out choice))
            {
                choice = 5;
            }
            return choice;

        }

        /// <summary>
        /// Show current page title
        /// </summary>
        /// <param name="title"></param>
        private static void ShowHeader(string title)
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(20, 0);
            Console.WriteLine(title);
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Display continue message
        /// </summary>
        public static void ShowContinueMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n------------------------------------------\n");
            Console.ResetColor();
            Console.WriteLine("Operation completed! \n" +
                "Press return key to continue...");
            Console.Read();
        }

        /// <summary>
        /// display 'add new user' dialog
        /// </summary>
        /// <returns></returns>
        public static User ShowAddNewUser()
        {
            ShowHeader("Add new user");

            var user = new User();

            Console.Write("Enter user full name: ");
            user.FullName = Console.ReadLine();

            Console.Write("Enter user email address: ");
            user.Email = Console.ReadLine();

            return user;
        }

        /// <summary>
        /// Display 'show user list' dialog
        /// </summary>
        /// <param name="usersList"></param>
        public static void ShowUsersList(List<User> usersList)
        {
            ShowHeader("Users list");

            var table = new TableHelper("Id", "Name", "Email", "Confirmed");

            foreach (var user in usersList)
            {
                table.AddRow(user.Id, user.FullName, user.Email, user.HasConfirmed);
            }
            table.Print();

            ShowContinueMessage();
        }

        /// <summary>
        /// Display 'Update user' dialog
        /// </summary>
        /// <returns></returns>
        public static string ShowUpdateUser()
        {
            ShowHeader("Update User");

            Console.Write("Enter user Id: ");

            return Console.ReadLine();

        }

        /// <summary>
        /// Display 'Delete user' dialog
        /// </summary>
        /// <returns></returns>
        public static string ShowDeleteUser()
        {
            ShowHeader("Delete User");

            Console.Write("Enter user ID: ");

            return Console.ReadLine();
        }

    }
}
