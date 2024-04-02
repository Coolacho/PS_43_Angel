using DataLayer.Model;
using DataLayer.Database;
using Welcome.Others;
using System.Diagnostics;
using Welcome.Model;
using System.Data;

using (var context = new DatabaseContext())
{
    context.Database.EnsureCreated();
    context.Add<DatabaseUser>(new DatabaseUser()
    {
        Name = "user",
        Password = "password",
        Expires = DateTime.Now,
        Role = UserRolesEnum.STUDENT,
        Email = "acho@gazpacho.com",
        Telephone = "0777344366",
        Fac_num = "121221037",
        Grade = 4.56
    });
    context.SaveChanges();

    int command;

    while (true)
    {
        Console.Clear();
        Console.WriteLine("Welcome to user menu!\n" +
            "Choose what you want to do from the options bellow:\n" +
            "1. Get all users in the database\n" +
            "2. Add a new user\n" +
            "3. Delete user\n" +
            "Type 0 to exit\n");
        command = Int32.Parse(Console.ReadLine());
        if (command == 0)
        {
            Console.WriteLine("\nThank you! Goodbye!");
            break;
        }
        else if (command == 1)
        {
            context.Users.ToList().ForEach(user => Console.WriteLine(user.ToString()));
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        else if (command == 2)
        {
            Console.WriteLine("\nEnter user's name: ");
            var name = Console.ReadLine();
            if (name != null)
            {
                Console.WriteLine("\nEnter user's password: ");
                var password = Console.ReadLine();
                if (password != null)
                {
                    context.Add(new DatabaseUser()
                    {
                        Name = name,
                        Password = password,
                        Expires = DateTime.Now,
                        Role = UserRolesEnum.ANONYMOUS,
                        Email = "",
                        Telephone = "",
                        Fac_num = "",
                        Grade = 0.0
                    });
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("\nPassword cannot be empty! Try again!");
                }
            }
            else
            {
                Console.WriteLine("\nName cannot be empty! Try again!");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

        }
        else if (command == 3)
        {
            Console.WriteLine("\nEnter user's name: ");
            var name = Console.ReadLine();
            if (name != null)
            {
                var user = context.Users.Where(x => x.Name == name )
                        .FirstOrDefault();
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("\nNo such user! Try again!\n");
                }
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("\nWrong command! Try again!\n");
            Console.ReadKey();
        }
    }
}