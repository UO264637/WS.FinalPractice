using WSClient.UsersWS;

internal class Program
{
    private static string SERVICE_URL = "http://156.35.98.70:8080/ws.finalpractice.usersws/soapws/users";
    private static void Main(string[] args)
    {
        UsersWSClient client = new UsersWSClient(
               UsersWSClient.EndpointConfiguration.UsersWSPort, SERVICE_URL);

        string command = "";

        while (command != "exit")
        {
            ListCommands();
            command = Console.ReadLine().ToLower();
            switch (command)
            {
                case "add":
                    {
                        AddUser(client);
                        break;
                    }
                case "del":
                    {
                        DeleteUser(client);
                        break;
                    }
                case "list":
                    {
                        ListUsers(client);
                        break;
                    }
                case "exit":
                    {
                        break;
                    }
                default:
                    Console.WriteLine("\nUnknown command");
                    break;
            }
        }
    }

    public static void ListCommands()
    {
        Console.WriteLine("\nEnter one of the following commands:");
        Console.WriteLine(" add - Add new user");
        Console.WriteLine(" del - Delete existent user");
        Console.WriteLine(" list - List all users");
        Console.WriteLine(" exit - Exit program");
    }
     
    public static void AddUser(UsersWSClient client)
    {
        Console.WriteLine("\nEnter username:");
        string username = Console.ReadLine();
        Console.WriteLine("Enter password:");
        string password = ReadPassword();
        Console.WriteLine("\nEnter email:");
        string email = Console.ReadLine();
        Console.WriteLine("Enter full name:");
        string fullname = Console.ReadLine();

        user userToAdd = new user { userName= username, password = password, fullName=fullname, email=email };

        try
        {
            var result = client.addUserAsync(userToAdd).Result;
            Console.WriteLine("\n " + username + " user created successfully!!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("\n \"" + username + "\" username is already taken");
        }
    }
    
    public static void DeleteUser(UsersWSClient client)
    {
        Console.WriteLine("\nEnter username from user to delete:");
        string username = Console.ReadLine();

        try
        {
            var result = client.deleteUserAsync(username).Result;
            Console.WriteLine("\n " + username + " user deleted successfully!!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("\n User with the specified username does not exist");
        }
    }
     
    public static void ListUsers(UsersWSClient client)
    {
        var users = client.getUsersAsync().Result.@return;
        Console.WriteLine("\nUsers:");

        if (users != null)
        { 
            foreach (var user in users)
            {
                Console.WriteLine(" " + user.userName + " - Email: " + user.email + " Full Name: " + user.fullName);
            }
        }
        else
        {
            Console.WriteLine(" [empty]");
        }
    }

    public static string ReadPassword()
    {
        var pass = string.Empty;
        ConsoleKey key;
        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && pass.Length > 0)
            {
                Console.Write("\b \b");
                pass = pass[0..^1];
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");
                pass += keyInfo.KeyChar;
            }
        } while (key != ConsoleKey.Enter);
        return pass;
    }
}