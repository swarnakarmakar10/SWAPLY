using System;
using System.Data;
using System.Windows.Forms;
using CampusMarketPlace;
using User = CampusMarketPlace.User;

namespace Second_Hand_Item_Ex_
{
    public partial class CreateAdminPanelForm : Form
    {
        private MarketPlace marketplace;
        private User currentUser;
        private MainForm mainForm;

        public CreateAdminPanelForm(MarketPlace marketplace, User currentUser, MainForm mainForm)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.marketplace = marketplace;
            this.currentUser = currentUser;
            this.mainForm = mainForm;

            LoadAdminTable();

            button1.Click += button1_Click; // Create Admin
            button2.Click += button2_Click; // Back
            button3.Click += button3_Click; // Show/Hide Password
            button4.Click += button4_Click; // Delete Admin

            // Placeholder behavior
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;
            textBox2.Enter += textBox2_Enter;
            textBox2.Leave += textBox2_Leave;
            textBox3.Enter += textBox3_Enter;
            textBox3.Leave += textBox3_Leave;
        }

        private void LoadAdminTable()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            DataTable admins = DatabaseHelper.GetAllAdmins();

            DataColumn noColumn = new DataColumn("No.", typeof(int));
            admins.Columns.Add(noColumn);
            admins.Columns["No."].SetOrdinal(0);

            int rowNumber = 1;
            foreach (DataRow row in admins.Rows)
            {
                row["No."] = rowNumber;
                rowNumber++;
            }

            dataGridView1.DataSource = admins;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns["No."].Width = 40;
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
                textBox3.PasswordChar = '\0';
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
            marketplace.RegisterUser(newAdmin, currentUser.Username);

            MessageBox.Show("New admin account created: " + username, "Success");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            LoadAdminTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool isHidden = textBox3.PasswordChar == '*';

            textBox3.PasswordChar = isHidden ? '\0' : '*';
            button3.Text = isHidden ? "🙈" : "👁";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select an admin to delete.", "No Selection");
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            int selectedId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            string selectedUsername = selectedRow.Cells["Username"].Value.ToString();

            int adminCount = 0;
            foreach (User u in marketplace.Users)
            {
                if (u is Admin)
                    adminCount++;
            }

            if (adminCount <= 1)
            {
                MessageBox.Show("Cannot delete the last remaining admin account.", "Action Blocked");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete admin \"" + selectedUsername + "\"?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            marketplace.DeleteAdmin(selectedId);

            bool deletedSelf = selectedUsername == currentUser.Username;

            if (deletedSelf)
            {
                MessageBox.Show("Your admin account has been deleted. You will be logged out.",
                    "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                mainForm.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Admin \"" + selectedUsername + "\" has been deleted.", "Success");
                LoadAdminTable();
            }
        }
    }
}