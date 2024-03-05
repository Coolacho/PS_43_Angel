using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    public class Program
    {
        static void Main(string[] args)
        {
            User user1 = new("Gazpacho", "1234", UserRolesEnum.ADMIN, "gazpacho@tu-sofia", "0888555333", "", 0.0);
            UserViewModel viewModel1 = new(user1);
            UserView view1 = new(viewModel1);
            UserViewContacts view_contacts1 = new(viewModel1);
            UserViewGrade view_grade1 = new(viewModel1);
            view1.Display();
            view_contacts1.Display();
            view_grade1.Display();

            User user2 = new("Acho", "5678", UserRolesEnum.STUDENT, "acho@tu-sofia", "0777666444", "121221038", 5.95);
            UserViewModel viewModel2 = new(user2);
            UserView view2 = new(viewModel2);
            UserViewContacts view_contacts2 = new(viewModel2);
            UserViewGrade view_grade2 = new(viewModel2);
            view2.Display();
            view_contacts2.Display();
            view_grade2.Display();
        }
    }
}