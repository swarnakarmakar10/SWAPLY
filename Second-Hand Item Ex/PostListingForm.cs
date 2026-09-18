using System;
using System.Windows.Forms;
using CampusMarketPlace;
using User = CampusMarketPlace.User;

namespace Second_Hand_Item_Ex_
{
    public partial class PostListingForm : Form
    {
        private MarketPlace marketplace;
        private User currentUser;

        public PostListingForm(MarketPlace marketplace, User currentUser)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.marketplace = marketplace;
            this.currentUser = currentUser;


            comboBox1.SelectedIndex = 0;

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            button1.Click += button1_Click; // Post
            button2.Click += button2_Click; // Back
            button3.Click += button3_Click;

            UpdateFieldsVisibility();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFieldsVisibility();
        }

        private void UpdateFieldsVisibility()
        {
            string type = comboBox1.SelectedItem.ToString();

            if (type == "BOOK")
            {
                label2.Text = "";
                label3.Text = "Course Code:";
                label4.Text = "Author Name:";
                label5.Text = "Edition:";
                label6.Text = "Condition:";

                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
            }
            else if (type == "EQUIPMENT")
            {
                label2.Text = "";
                label3.Text = "Equipment Type:";
                label4.Text = "Condition:";

                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = false;
                textBox6.Visible = false;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = false;
                label6.Visible = false;
            }
            else // NOTE
            {
                label2.Text = "";
                label3.Text = "Course Code:";
                label4.Text = "Semester:";
                label5.Text = "Format:";

                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = false;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string itemName = textBox1.Text.Trim();
            string description = textBox2.Text.Trim();
            string d1 = textBox3.Text.Trim();
            string d2 = textBox4.Text.Trim();
            string d3 = textBox5.Text.Trim();
            string d4 = textBox6.Text.Trim();

            if (string.IsNullOrWhiteSpace(itemName))
            {
                MessageBox.Show("Please enter an item name.", "Invalid Input");
                return;
            }

            string type = comboBox1.SelectedItem.ToString();
            Listing newListing;
            

            if (type == "BOOK")
            {
                newListing = new BookListing
                {
                    ItemName = itemName,
                    Description = description,
                    Owner = currentUser,
                    DatePosted = DateTime.Now,
                    Status = ListingStatus.Available,
                    CourseCode = d1,
                    Author = d2,
                    Edition = d3,
                    Condition = d4,
                    ImageData = selectedImageBytes
                };
            }
            else if (type == "EQUIPMENT")
            {
                newListing = new EquipmentListing
                {
                    ItemName = itemName,
                    Description = description,
                    Owner = currentUser,
                    DatePosted = DateTime.Now,
                    Status = ListingStatus.Available,
                    EquipmentType = d1,
                    Condition = d2,
                    ImageData = selectedImageBytes
                };
            }
            else // NOTE
            {
                newListing = new NoteListing
                {
                    ItemName = itemName,
                    Description = description,
                    Owner = currentUser,
                    DatePosted = DateTime.Now,
                    Status = ListingStatus.Available,
                    CourseCode = d1,
                    Semester = d2,
                    Format = d3,
                    ImageData = selectedImageBytes
                };
            }

            marketplace.PostListing(newListing);
            MessageBox.Show("Listing posted: " + itemName, "Success");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            pictureBox1.Image = null;
            selectedImageBytes = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(marketplace, currentUser);
            mainForm.Show();
            this.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            // Not used, but required because the Designer wires this event.
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private byte[] selectedImageBytes = null;
      
        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*,png;*.bmp";

                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImageBytes = System.IO.File.ReadAllBytes(dialog.FileName);
                    pictureBox1.Image = System.Drawing.Image.FromFile(dialog.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                }
            }

        }
    }
}