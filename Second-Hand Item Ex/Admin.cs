using System;
using System.Collections.Generic;
using System.Text;

namespace CampusMarketPlace
{
    public class Admin : User
    {
        public Admin(int id, string username, string email, string password)
            : base(id, username, email, password)
        {
        }

        public override string ToString()
        {
            return $"Admin[Id={Id}, Username={Username}, Email={Email}]";
        }
    }
}