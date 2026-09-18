using System;
using System.Collections.Generic;
using System.Text;

namespace CampusMarketPlace
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(int id, string username, string email, string password)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return $"User[Id={Id}, Username={Username}, Email={Email}]";
        }
    }
}