using System;
using System.Windows.Forms;
using CampusMarketPlace;
using User = CampusMarketPlace.User;

namespace Second_Hand_Item_Ex_
{
    internal static class Program
    {
        public static MarketPlace Marketplace = new MarketPlace();
        public static User CurrentUser;   // ← new

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Seed one admin account so the Admin Panel can actually be reached.
            // Log in with Username: admin  Password: admin123
            Admin admin = new Admin(1, "admin", "admin@campus.edu", "admin123");
            Marketplace.RegisterUser(admin);

            Application.Run(new LoginForm());
        }
    }
}
