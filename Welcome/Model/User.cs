﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        public virtual int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserRolesEnum Role { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public string Fac_num { get; set; }

        public double Grade { get; set; }

        public DateTime Expires { get; set; }

        public User()
        {

        }

        public User (string name, string password, DateTime expireDate, UserRolesEnum role, string email, string telephone, string fac_num, double grade)
        {
            Name = name;
            Password = password;
            Expires = expireDate;
            Role = role;
            Email = email;
            Telephone = telephone;
            Fac_num = fac_num;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Password: {Password}\n" +
                $"Expires: {Expires}\n" +
                $"Role: {Role}\n" +
                $"Email: {Email}\n" +
                $"Telephone: {Telephone}\n" +
                $"Fac num: {Fac_num}\n" +
                $"Grade: {Grade}\n";
        }
    }
}
