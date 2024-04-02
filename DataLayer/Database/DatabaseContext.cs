using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;
using Welcome.Others;

namespace DataLayer.Database
{
    public class DatabaseContext:DbContext
    {
        public DbSet<DatabaseUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFile = "Welcome.db";
            optionsBuilder.UseSqlite($"Data Source={databaseFile}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();

            //Create user
            var user = new DatabaseUser()
            {
                Id = 1,
                Name = "John Doe",
                Password = "1234",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10),
                Email = "acho@gazpacho.com",
                Telephone = "0777344366",
                Fac_num = "121221037",
                Grade = 4.56
            };

            modelBuilder.Entity<DatabaseUser>().HasData(user);
        }

    }
}
