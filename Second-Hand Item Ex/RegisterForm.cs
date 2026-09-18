using System;
using System.Windows.Forms;
using CampusMarketPlace;
using User = CampusMarketPlace.User;

namespace Second_Hand_Item_Ex_
{
    public partial class RegisterForm : Form
    {
        private MarketPlace marketplace;
        private const string AdminPasskey = "ADMIN-2026";
        private LoginForm loginForm;

        public RegisterForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.marketplace = Program.Marketplace;
            this.loginForm = loginForm;

            button1.Click += button1_Click; // Register
            button2.Click += button2_Click; // Log In
            button3.Click += button3_Click; // Show/Hide Password

            radioButton1.CheckedChanged += radioButton_CheckedChanged;
            radioButton2.CheckedChanged += radioButton_CheckedChanged;

            // Placeholder behavior
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;
            textBox2.Enter += textBox2_Enter;
            textBox2.Leave += textBox2_Leave;
            textBox3.Enter += textBox3_Enter;
            textBox3.Leave += textBox3_Leave;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            bool isAdmin = radioButton2.Checked;
            label4.Visible = isAdmin;
            textBox4.Visible = isAdmin;
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
            if (textBox2.Text == "Enter your Email")
                textBox2.Text = "";
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
                textBox2.Text = "Enter your Email";
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
                textBox3.PasswordChar = '\0';
                textBox3.Text = "Enter your Password";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string password = textBox3.Text.Trim();
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || 
                string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username is invalid. Please enter a username.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email is invalid. Please enter an email.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!email.EndsWith("@gmail.com") && !email.EndsWith("@yahoo.com"))
            {
                MessageBox.Show("Invalid Email entered.", "Invalid Email",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password is invalid. Please enter a password.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (User u in marketplace.Users)
            {
                if (u.Username == username)
                {
                    MessageBox.Show("This username is already registered. Please log in instead.",
                        "Already Registered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int newId = marketplace.Users.Count + 1;
            User newUser;

            if (radioButton2.Checked)
            {
                if (textBox4.Text.Trim() != AdminPasskey)
                {
                    MessageBox.Show("Incorrect admin passkey.",
                        "Invalid Passkey", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                newUser = new Admin(newId, username, email, password);
            }
            else
            {
                newUser = new User(newId, username, email, password);
            }

            marketplace.RegisterUser(newUser);

            MessageBox.Show("Registration successful! Please log in.",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();
            loginForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool isHidden = textBox2.PasswordChar == '*';

            textBox2.PasswordChar = isHidden ? '\0' : '*';
            button3.Text = isHidden ? "🙈" : "👁";
        }
    }
}