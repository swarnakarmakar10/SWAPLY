using System;
using System.Drawing;
using System.Windows.Forms;
using CampusMarketPlace;
using User = CampusMarketPlace.User;

namespace Second_Hand_Item_Ex_
{
    public partial class AdminPanelForm : Form
    {
        private MarketPlace marketplace;
        private User currentUser;

        private TransactionRequest selectedRequest;
        private Panel selectedRequestCard;

        private Listing selectedListing;
        private Panel selectedListingCard;

        public AdminPanelForm(MarketPlace marketplace, User currentUser)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.marketplace = marketplace;
            this.currentUser = currentUser;

            LoadPendingRequests();
            LoadAllListings();

            button1.Click += button1_Click; // Approve
            button2.Click += button2_Click; // Reject
            button3.Click += button3_Click; // Delete Listing
            button4.Click += button4_Click; // Add New Listing
            button5.Click += button5_Click; // Back
            button6.Click += button6_Click; // Update Listing

        }

        // ---------- PENDING REQUESTS ----------

        private void LoadPendingRequests()
        {
            flowLayoutPanel1.Controls.Clear();
            selectedRequest = null;
            selectedRequestCard = null;

            foreach (TransactionRequest request in marketplace.Requests)
            {
                if (request.Status == TransactionStatus.Pending)
                {
                    Panel card = CreateRequestCard(request);
                    flowLayoutPanel1.Controls.Add(card);
                }
            }
        }

        private Panel CreateRequestCard(TransactionRequest request)
        {
            Panel card = new Panel();
            card.Width = flowLayoutPanel1.ClientSize.Width - 25;
            card.Height = 55;
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(5);
            card.Tag = request;

            Label mainLabel = new Label();
            mainLabel.Text = request.Requester.Username + " requested \"" + request.Listing.ItemName + "\"";
            mainLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            mainLabel.Location = new Point(10, 6);
            mainLabel.AutoSize = true;

            Label subLabel = new Label();
            subLabel.Text = "From: " + request.Listing.Owner.Username + " | Requested: " + request.RequestDate;
            subLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            subLabel.Location = new Point(10, 28);
            subLabel.AutoSize = true;

            card.Controls.Add(mainLabel);
            card.Controls.Add(subLabel);

            card.Click += RequestCard_Click;
            mainLabel.Click += RequestCard_Click;
            subLabel.Click += RequestCard_Click;

            return card;
        }

        private void RequestCard_Click(object sender, EventArgs e)
        {
            Panel clickedCard = sender is Panel panel ? panel : (Panel)((Control)sender).Parent;

            if (selectedRequestCard != null)
            {
                selectedRequestCard.BackColor = Color.White;
                selectedRequestCard.BorderStyle = BorderStyle.FixedSingle;
            }

            clickedCard.BackColor = Color.LightSteelBlue;
            clickedCard.BorderStyle = BorderStyle.Fixed3D;

            selectedRequestCard = clickedCard;
            selectedRequest = (TransactionRequest)clickedCard.Tag;
        }

        private void button1_Click(object sender, EventArgs e) // Approve
        {
            if (selectedRequest == null)
            {
                MessageBox.Show("Please select a request first.", "No Selection");
                return;
            }

            marketplace.AcceptRequest(currentUser, selectedRequest);
            LoadPendingRequests();
            LoadAllListings();
        }

        private void button2_Click(object sender, EventArgs e) // Reject
        {
            if (selectedRequest == null)
            {
                MessageBox.Show("Please select a request first.", "No Selection");
                return;
            }

            marketplace.RejectRequest(currentUser, selectedRequest);
            LoadPendingRequests();
        }

        // ---------- ALL LISTINGS ----------

        private void LoadAllListings()
        {
            flowLayoutPanel2.Controls.Clear();
            selectedListing = null;
            selectedListingCard = null;

            foreach (Listing listing in marketplace.Listings)
            {
                Panel card = CreateListingCard(listing);
                flowLayoutPanel2.Controls.Add(card);
            }
        }

        private Panel CreateListingCard(Listing listing)
        {
            Panel card = new Panel();
            card.Width = flowLayoutPanel2.ClientSize.Width - 25;
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

            Label ownerLabel = new Label();
            ownerLabel.Text = "Posted by: " + listing.Owner.Username + " | Status: " + listing.Status;
            ownerLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            ownerLabel.Location = new Point(textLeft, 54);
            ownerLabel.AutoSize = true;

            card.Controls.Add(pictureBox);
            card.Controls.Add(nameLabel);
            card.Controls.Add(detailsLabel);
            card.Controls.Add(ownerLabel);

            card.Click += ListingCard_Click;
            pictureBox.Click += ListingCard_Click;
            nameLabel.Click += ListingCard_Click;
            detailsLabel.Click += ListingCard_Click;
            ownerLabel.Click += ListingCard_Click;

            return card;
        }

        private void ListingCard_Click(object sender, EventArgs e)
        {
            Panel clickedCard = sender is Panel panel ? panel : (Panel)((Control)sender).Parent;

            if (selectedListingCard != null)
            {
                selectedListingCard.BackColor = Color.White;
                selectedListingCard.BorderStyle = BorderStyle.FixedSingle;
            }

            clickedCard.BackColor = Color.LightSteelBlue;
            clickedCard.BorderStyle = BorderStyle.Fixed3D;

            selectedListingCard = clickedCard;
            selectedListing = (Listing)clickedCard.Tag;
        }

        private void button3_Click(object sender, EventArgs e) // Delete Listing
        {
            if (selectedListing == null)
            {
                MessageBox.Show("Please select a listing first.", "No Selection");
                return;
            }

            marketplace.DeleteListing(currentUser, selectedListing);
            LoadAllListings();
        }

        private void button4_Click(object sender, EventArgs e) // Add New Listing
        {
            PostListingForm postForm = new PostListingForm(marketplace, currentUser);
            postForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e) // Back
        {
            MainForm mainForm = new MainForm(marketplace, currentUser);
            mainForm.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e) // Update Listing
        {
            if (selectedListing == null)
            {
                MessageBox.Show("Please select a listing first.", "No Selection");
                return;
            }

            UpdateListingForm updateForm = new UpdateListingForm(marketplace, selectedListing);
            updateForm.FormClosed += (s, args) => LoadAllListings(); // refresh cards after save
            updateForm.Show();
        }

        private void button7_Click(object sender, EventArgs e) // View User
        {
            if (selectedListing == null)
            {
                MessageBox.Show("Please select a listing first.", "No Selection");
                return;
            }

            User owner = selectedListing.Owner;
            MessageBox.Show(
                "Username: " + owner.Username + "\nEmail: " + owner.Email,
                "User Details");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            PostListingForm postForm = new PostListingForm(marketplace, currentUser);
            postForm.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}