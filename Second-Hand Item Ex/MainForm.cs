using System;
using System.Windows.Forms;
using CampusMarketPlace;
using User = CampusMarketPlace.User;

namespace Second_Hand_Item_Ex_
{
    public partial class MainForm : Form
    {
        private MarketPlace marketplace;
        private User currentUser;

        public MainForm(MarketPlace marketplace, User currentUser)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.marketplace = marketplace;
            this.currentUser = currentUser;

            label1.Text = "Welcome, " + currentUser.Username + "!";
            button5.Visible = currentUser is Admin;
            button7.Visible = currentUser is Admin;

            button1.Click += button1_Click; // Browse Listings
            button2.Click += button2_Click; // Post New Listing
            button3.Click += button3_Click; // My Listing
            button4.Click += button4_Click; // My Request
            button5.Click += button5_Click; // Admin Panel
            button6.Click += button6_Click; // Log Out
            button7.Click += button7_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BrowseListingForm browseForm = new BrowseListingForm(marketplace, currentUser);
            browseForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PostListingForm postForm = new PostListingForm(marketplace, currentUser);
            postForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyListingsForm myListingsForm = new MyListingsForm(marketplace, currentUser);
            myListingsForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MyRequestsForm myRequestsForm = new MyRequestsForm(marketplace, currentUser);
            myRequestsForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminPanelForm adminForm = new AdminPanelForm(marketplace, currentUser);
            adminForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            CreateAdminPanelForm createAdmin = new CreateAdminPanelForm(marketplace, currentUser);
            createAdmin.Show();
            this.Close();
        }
    }
}
