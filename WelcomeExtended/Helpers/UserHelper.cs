using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    public static class UserHelper
    {
        public static string ToString(this User user)
        {
            return "Welcome\nUser: " + user.Name + "\nRole: " + user.Role + "\n";
        }

        public static bool ValidateCredentials(this UserData userData, string name, string password)
        {
            if (name == "" )
            {
                throw new ArgumentException("The name cannot be empty!\n");
            }
            else if (password == "")
            {
                throw new ArgumentException("The password cannot be empty!\n");
            }
            else
            {
                return userData.ValidateUser(name, password);
            }
        }

        public static User GetUser(this UserData userData, string name, string password)
        {
            return userData.GetUser(name, password);
        }
    }
}
