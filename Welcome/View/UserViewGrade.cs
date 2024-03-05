using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.ViewModel;
using Welcome.Others;

namespace Welcome.View
{
    public class UserViewGrade
    {
        private UserViewModel _viewModel;

        public UserViewGrade(UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Display()
        {
            if (_viewModel.Role.Equals(UserRolesEnum.STUDENT))
            {
                Console.WriteLine("Student: " + _viewModel.Fac_num + " grade is: " + _viewModel.Grade + "\n");
            }
            else Console.WriteLine("User is not a student!\n");
        }
    }
}
