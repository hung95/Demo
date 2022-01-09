using Demo.Helper;
using Demo.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Text;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "mongodb+srv://orsontruong:Thisispassword%40123@cluster0.csqiw.mongodb.net/demoDB?retryWrites=true&w=majority";

            const string databaseName = "demoDB";
            const string collectionName = "user";

            MongoHelper database = new MongoHelper(connectionString, databaseName);

            Console.Title = "User List Manager";

            int menuChoice;

            do
            {
                menuChoice = MenuHelper.ShowMainMenu();
                switch (menuChoice)
                {
                    case 0: // Add new user
                        {
                            var user = MenuHelper.ShowAddNewUser();

                            database.InsertDocument(collectionName, user);

                            MenuHelper.ShowContinueMessage();
                        }
                        break;
                    case 1: // Show user list
                        {
                            var usersList = database.LoadAllDocuments<User>(collectionName);
                            MenuHelper.ShowUsersList(usersList);

                        }
                        break;
                    case 2: // Update user info (by ID)
                        {
                            var userId = MenuHelper.ShowUpdateUser();
                            ObjectId userObjectId;
                            bool isValidObjectId = ObjectId.TryParse(userId, out userObjectId);
                            if (isValidObjectId)
                            {
                                var user = database.LoadDocumentById<User>(collectionName, userObjectId);
                                if(user!= null)
                                {
                                    Console.Write($"\n" +
                                    $"Current info\n" +
                                    $"Name: {user.FullName} \n" +
                                    $"Email: {user.Email}");

                                    Console.WriteLine("\n------------------------------------------\n");

                                    Console.WriteLine("Enter new full name (leave empty if no changes)");
                                    var fullName = Console.ReadLine();

                                    if (!string.IsNullOrEmpty(fullName) && !string.IsNullOrWhiteSpace(fullName))
                                    {
                                        user.FullName = fullName;
                                    }

                                    Console.WriteLine("Enter new email (leave empty if no changes)");
                                    var email = Console.ReadLine();

                                    if (!string.IsNullOrEmpty(email) && !string.IsNullOrWhiteSpace(email))
                                    {
                                        user.Email = email;
                                    }

                                    database.UpdateDocument<User>(collectionName, userObjectId, user);
                                }
                                else
                                {
                                    Console.WriteLine($"Exception: User with id:'{userId}' not found!");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Exception: '{userId}' is not a valid ObjectId!");
                            }

                            MenuHelper.ShowContinueMessage();
                        }
                        break;
                    case 3: // Delete user (by ID)
                        {
                            var userId = MenuHelper.ShowDeleteUser();

                            ObjectId userObjectId;

                            bool isValidGuid = ObjectId.TryParse(userId, out userObjectId);
                            if (isValidGuid)
                            {
                                database.DeleteDocument<User>(collectionName, userObjectId);
                            }
                            else
                            {
                                Console.WriteLine($"Exception: '{userId}' is not a valid ObjectId!");
                            }


                            MenuHelper.ShowContinueMessage();
                        }
                        break;
                }

            } while (menuChoice != 4);
        }
    }
}
