using DataLayer.Model;
using DataLayer.Database;
using Welcome.Others;
using System.Diagnostics;

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
    var user = context.Users.ToList();
    Console.ReadKey();
}