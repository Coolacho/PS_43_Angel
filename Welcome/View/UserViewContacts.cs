using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserViewContacts
    {
        private UserViewModel _viewModel;

        public UserViewContacts (UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Display()
        {
            Console.WriteLine("User: " + _viewModel.Name + " contacts' are:\n" + "Email: " + _viewModel.Email + "\nTelephone: " + _viewModel.Telephone + "\n");
        }
    }
}
