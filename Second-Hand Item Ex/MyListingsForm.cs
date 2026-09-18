using System;
using System.Drawing;
using System.Windows.Forms;
using CampusMarketPlace;
using User = CampusMarketPlace.User;

namespace Second_Hand_Item_Ex_
{
    public partial class MyListingsForm : Form
    {
        private MarketPlace marketplace;
        private User currentUser;

        public MyListingsForm(MarketPlace marketplace, User currentUser)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.marketplace = marketplace;
            this.currentUser = currentUser;

            LoadMyListings();

            button1.Click += button1_Click; 
        }

        private void LoadMyListings()
        {
            flowLayoutPanel1.Controls.Clear();

            bool hasAny = false;

            foreach (Listing listing in marketplace.Listings)
            {
                if (listing.Owner.Id == currentUser.Id)
                {
                    hasAny = true;
                    Panel card = CreateListingCard(listing);
                    flowLayoutPanel1.Controls.Add(card);
                }
            }

            if (!hasAny)
            {
                Label emptyLabel = new Label();
                emptyLabel.Text = "You haven't posted any listings yet.";
                emptyLabel.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
                emptyLabel.AutoSize = true;
                emptyLabel.Location = new Point(10, 10);
                flowLayoutPanel1.Controls.Add(emptyLabel);
            }
        }

        private Panel CreateListingCard(Listing listing)
        {
            Panel card = new Panel();
            card.Width = flowLayoutPanel1.ClientSize.Width - 25;
            card.Height = 90;
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(5);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Width = 80;
            pictureBox.Height = 70;
            pictureBox.Location = new Point(10, 8);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;

            if (listing.ImageData != null && listing.ImageData.Length > 0)
            {
                using (var ms = new System.IO.MemoryStream(listing.ImageData))
                {
                    pictureBox.Image = Image.FromStream(ms);
                }
            }

            int textLeft = 100;

            Label nameLabel = new Label();
            nameLabel.Text = listing.ItemName;
            nameLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            nameLabel.Location = new Point(textLeft, 8);
            nameLabel.AutoSize = true;

            Label detailsLabel = new Label();
            detailsLabel.Text = listing.GetCategoryDetails();
            detailsLabel.Font = new Font("Segoe UI", 9F);
            detailsLabel.Location = new Point(textLeft, 32);
            detailsLabel.AutoSize = true;

            Label statusLabel = new Label();
            statusLabel.Text = "Status: " + listing.Status;
            statusLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            statusLabel.Location = new Point(textLeft, 54);
            statusLabel.AutoSize = true;

            card.Controls.Add(pictureBox);
            card.Controls.Add(nameLabel);
            card.Controls.Add(detailsLabel);
            card.Controls.Add(statusLabel);

            return card;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(marketplace, currentUser);
            mainForm.Show();
            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}