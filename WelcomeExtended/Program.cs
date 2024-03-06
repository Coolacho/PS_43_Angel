using Welcome.Model;
using Welcome.Others;
using Welcome.ViewModel;
using Welcome.View;
using WelcomeExtended.Others;

try
{
    //Example 2
    var user = new User
    {
        Name = "John Smith",
        Password = "password123",
        Role = UserRolesEnum.STUDENT,
        Email = "johnsmith@gmail.com",
        Telephone = "0885464733",
        Fac_num = "121221037",
        Grade = 4.50
    };

    var viewModel = new UserViewModel(user);

    var view = new UserView(viewModel);

    view.Display();

    //Throw error here
    view.DisplayError();
}
catch (Exception e)
{
    var log = new ActionOnError(Delegates.Log);
    log(e.Message);
}
finally
{
    Console.WriteLine("Executed in any case!");
}