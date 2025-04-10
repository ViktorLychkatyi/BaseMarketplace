﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseMarketplace.Contexts;
using BaseMarketplace.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Dapper;
using System.Data.SqlClient;

namespace BaseMarketplace.Repositories
{
    public class UserRepository
    {
        private readonly string connectionString = "YourConnectionStringHere"; // Add this line to define connectionString

        public void AddUser(string name, string email, string password)
        {
            name = string.IsNullOrWhiteSpace(name) ? null : name;
            using (var context = new ApplicationDbContext())
            {
                var user = new User { Name = name, Email = email, Password = password };

                context.Users.Add(user);
                context.SaveChanges();

                Console.WriteLine($"Пользователь {user.Name} добавлен!");
            }
        }

        public void GetAll()
        {
            using (var context = new ApplicationDbContext())
            {
                var users = context.Users.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine($"UserId: {user.UserId}\nName: {user.Name}\nEmail: {user.Email}\n");
                }
            }
        }

        public void GetById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users.Find(id);
                Console.WriteLine($"UserId: {user.UserId}\nName: {user.Name}\nEmail: {user.Email}\n");
            }
        }

        public void UpdateUser(int user_id, string name, string email, string password)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = new User { UserId = user_id, Name = name, Email = email, Password = password };

                context.Users.Update(user);
                context.SaveChanges();

                Console.WriteLine($"Пользователь {user.Name}, ID: {user.UserId} обновлен!");
            }
        }

        public void DeleteUser(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users.Find(id);

                context.Users.Remove(user);
                context.SaveChanges();

                Console.WriteLine($"Пользователь {user.Name} удален!");
            }
        }
    }
}
