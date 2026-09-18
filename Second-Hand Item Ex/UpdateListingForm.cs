using System;
using System.Windows.Forms;
using CampusMarketPlace;

namespace Second_Hand_Item_Ex_
{
    public partial class UpdateListingForm : Form
    {
        private MarketPlace marketplace;
        private Listing originalListing;
        private string originalItemName; // preserved as the WHERE-clause key, even if ItemName is edited
        private byte[] updatedImageBytes;

        public UpdateListingForm(MarketPlace marketplace, Listing listing)
        {
            Console.WriteLine("UpdateListingForm constructor called"); // TEMP DEBUG
           
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.marketplace = marketplace;
            this.originalListing = listing;
            this.originalItemName = listing.ItemName;
            this.updatedImageBytes = listing.ImageData;

            this.StartPosition = FormStartPosition.CenterScreen;

            PopulateFields();

            button1.Click += button1_Click; // Save Changes
            button2.Click += button2_Click; // Cancel
            button3.Click += button3_Click; // Change Image
        }

        private void PopulateFields()
        {
            textBox1.Text = originalListing.ItemName;
            textBox2.Text = originalListing.Description;

            if (originalListing is BookListing book)
            {
                label7.Text = "Category: Book";

                label3.Text = "Course Code:";
                label4.Text = "Author:";
                label5.Text = "Edition:";
                label6.Text = "Condition:";

                textBox3.Text = book.CourseCode;
                textBox4.Text = book.Author;
                textBox5.Text = book.Edition;
                textBox6.Text = book.Condition;

                textBox5.Visible = true;
                textBox6.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
            }
            else if (originalListing is EquipmentListing eq)
            {
                label7.Text = "Category: Equipment";

                label3.Text = "Equipment Type:";
                label4.Text = "Condition:";

                textBox3.Text = eq.EquipmentType;
                textBox4.Text = eq.Condition;

                textBox5.Visible = false;
                textBox6.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
            }
            else if (originalListing is NoteListing note)
            {
                label7.Text = "Category: Note";

                label3.Text = "Course Code:";
                label4.Text = "Semester:";
                label5.Text = "Format:";

                textBox3.Text = note.CourseCode;
                textBox4.Text = note.Semester;
                textBox5.Text = note.Format;

                textBox5.Visible = true;
                textBox6.Visible = false;
                label5.Visible = true;
                label6.Visible = false;
            }

            if (originalListing.ImageData != null && originalListing.ImageData.Length > 0)
            {
                using (var ms = new System.IO.MemoryStream(originalListing.ImageData))
                {
                    pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) // Change Image
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    updatedImageBytes = System.IO.File.ReadAllBytes(dialog.FileName);
                    pictureBox1.Image = System.Drawing.Image.FromFile(dialog.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) // Save Changes
        {
            string itemName = textBox1.Text.Trim();
            string description = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(itemName))
            {
                MessageBox.Show("Item name cannot be empty.", "Invalid Input");
                return;
            }

            originalListing.ItemName = itemName;
            originalListing.Description = description;

            if (originalListing is BookListing book)
            {
                book.CourseCode = textBox3.Text.Trim();
                book.Author = textBox4.Text.Trim();
                book.Edition = textBox5.Text.Trim();
                book.Condition = textBox6.Text.Trim();
            }
            else if (originalListing is EquipmentListing eq)
            {
                eq.EquipmentType = textBox3.Text.Trim();
                eq.Condition = textBox4.Text.Trim();
            }
            else if (originalListing is NoteListing note)
            {
                note.CourseCode = textBox3.Text.Trim();
                note.Semester = textBox4.Text.Trim();
                note.Format = textBox5.Text.Trim();
            }

            originalListing.ImageData = updatedImageBytes;

            marketplace.UpdateListing(originalItemName, originalListing.Owner.Id, originalListing);

            MessageBox.Show("Listing updated: " + itemName, "Success");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) // Cancel
        {
            this.Close();
        }
    }
}