using System;
using System.Drawing;
using System.Windows.Forms;
using CampusMarketPlace;
using User = CampusMarketPlace.User;

namespace Second_Hand_Item_Ex_
{
    public partial class BrowseListingForm : Form
    {
        private MarketPlace marketplace;
        private User currentUser;
        private Listing selectedListing;
        private Panel selectedCard;

        public BrowseListingForm(MarketPlace marketplace, User currentUser)
        {
            InitializeComponent();
            this.marketplace = marketplace;
            this.currentUser = currentUser;

            LoadListings();

            button1.Click += button1_Click; // Request This Item
            button2.Click += button2_Click; // Back
        }

        private void LoadListings()
        {
            flowLayoutPanel1.Controls.Clear();
            selectedListing = null;
            selectedCard = null;

            foreach (Listing listing in marketplace.GetAvailableListings())
            {
                Panel card = CreateListingCard(listing);
                flowLayoutPanel1.Controls.Add(card);
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
            card.Tag = listing;

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

            int textLeft = 100; // leaves room for the 80px-wide picture box + padding

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

            Label ownerLabel = new Label();
            ownerLabel.Text = "Posted by: " + listing.Owner.Username + " | Status: " + listing.Status;
            ownerLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            ownerLabel.Location = new Point(textLeft, 54);
            ownerLabel.AutoSize = true;

            card.Controls.Add(pictureBox);
            card.Controls.Add(nameLabel);
            card.Controls.Add(detailsLabel);
            card.Controls.Add(ownerLabel);

            card.Click += Card_Click;
            pictureBox.Click += Card_Click;
            nameLabel.Click += Card_Click;
            detailsLabel.Click += Card_Click;
            ownerLabel.Click += Card_Click;

            return card;
        }

        private void Card_Click(object sender, EventArgs e)
        {
            Panel clickedCard;
            if (sender is Panel panel)
                clickedCard = panel;
            else
                clickedCard = (Panel)((Control)sender).Parent;

            if (selectedCard != null)
            {
                selectedCard.BackColor = Color.White;
                selectedCard.BorderStyle = BorderStyle.FixedSingle;
            }

            clickedCard.BackColor = Color.LightSteelBlue;
            clickedCard.BorderStyle = BorderStyle.Fixed3D;

            selectedCard = clickedCard;
            selectedListing = (Listing)clickedCard.Tag;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedListing == null)
            {
                MessageBox.Show("Please select a listing first.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (selectedListing.Owner.Id == currentUser.Id)
            {
                MessageBox.Show("You cannot request your own listing.",
                    "Invalid Request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            marketplace.RequestTransaction(currentUser, selectedListing);

            MessageBox.Show("Request sent for " + selectedListing.ItemName,
                "Request Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadListings();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(marketplace, currentUser);
            mainForm.Show();
            this.Close();
        }
    }
}