namespace ConsoleApp2
{
    internal class Program
    {
        static User[] users = [new("kenan", "2133", Role.Admin), new("ferid", "4455", Role.User)];
        static void Main(string[] args)
        {
            var storage = new Storage();
            User user;
            do
            {
                Console.Write("Username:");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                user = GetUser(username, password);
            } while (user.Username == "undefined");

            if (user.Role == Role.Admin)
            {
                Console.WriteLine($"Welcome {user.Username}");
                do
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("[0]: Show Movie");
                    Console.WriteLine("[1]: Add Movie");
                    Console.WriteLine("[2]: Remove Movie");
                    Console.WriteLine("[3]: Add Genre");
                    Console.WriteLine("[4]: Remove Genre");
                    Console.WriteLine("[5]: Most Viewed Movie");
                    Console.WriteLine("[logout]: Logout");
                    Console.WriteLine("[exit]: Exit");

                    string command = Console.ReadLine();
                    switch (command)
                    {
                        case "0":
                            storage.PrintMovie();
                            break;
                        case "1":
                            storage.AddMovie();
                            break;
                        case "2":
                            storage.RemoveMovie();
                            break;
                        case "3":
                           storage.AddGenre();
                            break;
                        case "4":
                          storage.RemoveGenre();
                            break;
                        case "5":
                            storage.MostView();
                            break;
                        case "logout":
                            return;
                        case "exit":
                            break;
                        default:
                            Console.WriteLine("Invalid command!");
                            break;
                    }
                } while (true);
            }
            else
            {
                Console.WriteLine($"Welcome {user.Username}");
                do
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("[1]: Watch Movie");
                    Console.WriteLine("[2]: Filter Movies by Genre");
                    Console.WriteLine("[3]: Add to Watchlist");
                    Console.WriteLine("[4]: Search Movie");
                    Console.WriteLine("[logout]: Logout");
                    Console.WriteLine("[exit]: Exit");

                    string command = Console.ReadLine();
                    switch (command)
                    {
                        case "1":
                            Console.WriteLine("Watching movie...");
                            break;
                        case "2":
                            Console.WriteLine("Filtering movies...");
                            break;
                        case "3":
                            storage.AddToWatchlist(); 
                            break;
                        case "4":
                            Console.WriteLine("Searching movie...");
                            break;
                        case "logout":
                            return;
                        case "exit":
                            break;
                        default:
                            Console.WriteLine("Invalid command!");
                            break;
                    }
                } while (true);
            }

            static User GetUser(string username, string password)
            {
                foreach (var item in users)
                {
                    if (item.Username == username && item.Password == password)
                        return item;
                }
                return new("undefined", "undefined", (Role)2);
            }
        }
    }
}