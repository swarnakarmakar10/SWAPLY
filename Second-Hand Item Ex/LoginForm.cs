using System;
using System.Windows.Forms;
using CampusMarketPlace;
using User = CampusMarketPlace.User;

namespace Second_Hand_Item_Ex_
{
    public partial class LoginForm : Form
    {
        private MarketPlace marketplace;
        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            marketplace = Program.Marketplace;

            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;

            //PlaceHolder
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;
            textBox2.Enter += textBox2_Enter;
            textBox2.Leave += textBox2_Leave;

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
            if (textBox2.Text == "Enter your Password")
            {
                textBox2.Text = "";
                textBox2.PasswordChar = '*';

            }

        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.PasswordChar = '\0';
                textBox2.Text = "Enter your Password";
            }
        }


       

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username is Invalid! Please Enter an username.", "InValid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username is Invalid! Please Enter an username.", "InValid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) 
            {
                MessageBox.Show("Please enter both username and password.", "Login Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information); 
                return; 
            }

            User foundUser = DatabaseHelper.GetUserByCredentials(username, password);

            if (foundUser == null) 
            {
                MessageBox.Show("Incorrect username or password.", "Login Failed", 
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return; 
            }

            Program.CurrentUser = foundUser;

            MainForm mainForm = new MainForm(marketplace, foundUser);
            mainForm.Show();
            this.Hide();


        }
        private void button2_Click(object sender, EventArgs e)
        {
            RegisterForm registerform = new RegisterForm(this);
            this.Hide();
            registerform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool isHidden = textBox2.PasswordChar == '*';

            textBox2.PasswordChar = isHidden ? '\0' : '*';
            button3.Text = isHidden ? "🙈" : "👁";
        }


    }
}
