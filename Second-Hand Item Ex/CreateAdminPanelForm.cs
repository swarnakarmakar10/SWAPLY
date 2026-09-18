using System;
using System.Windows.Forms;
using CampusMarketPlace;
using User = CampusMarketPlace.User;

namespace Second_Hand_Item_Ex_
{
    public partial class CreateAdminPanelForm : Form
    {
        private MarketPlace marketplace;
        private User currentUser;

        public CreateAdminPanelForm(MarketPlace marketplace, User currentUser)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.marketplace = marketplace;
            this.currentUser = currentUser;

            button1.Click += button1_Click; // Create Admin
            button2.Click += button2_Click; // Back

            // Placeholder behavior
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;
            textBox2.Enter += textBox2_Enter;
            textBox2.Leave += textBox2_Leave;
            textBox3.Enter += textBox3_Enter;
            textBox3.Leave += textBox3_Leave;
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter your Username")
                textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
                textBox1.Text = "Enter your Username";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter Your Email")
                textBox2.Text = "";
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
                textBox2.Text = "Enter Your Email";
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Enter your Password")
            {
                textBox3.Text = "";
                textBox3.PasswordChar = '*';
            }
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                textBox3.PasswordChar = '\0'; // unmask so placeholder text is readable
                textBox3.Text = "Enter your Password";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string password = textBox3.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || username == "Enter your Username" ||
                string.IsNullOrWhiteSpace(email) || email == "Enter Your Email" ||
                string.IsNullOrWhiteSpace(password) || password == "Enter your Password")
            {
                MessageBox.Show("Please fill in username, email, and password.", "Invalid Input");
                return;
            }

            if (!email.EndsWith("@gmail.com") && !email.EndsWith("@yahoo.com"))
            {
                MessageBox.Show("Invalid Email entered.", "Invalid Email",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (User u in marketplace.Users)
            {
                if (u.Username == username)
                {
                    MessageBox.Show("That username is already taken.", "Invalid Input");
                    return;
                }
            }

            int newId = marketplace.Users.Count + 1;
            Admin newAdmin = new Admin(newId, username, email, password);
            marketplace.RegisterUser(newAdmin);

            MessageBox.Show("New admin account created: " + username, "Success");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(marketplace, currentUser);
            mainForm.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}