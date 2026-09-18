using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CampusMarketPlace
{
    public class MarketPlace
    {
        // --- USERS ---

        public List<User> Users
        {
            get
            {
                List<User> users = new List<User>();
                DataTable dt = DatabaseHelper.ExecuteQuery("SELECT Id, Username, Email, Password, IsAdmin FROM Users");

                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["Id"]);
                    string username = row["Username"].ToString();
                    string email = row["Email"].ToString();
                    string password = row["Password"].ToString();
                    bool isAdmin = Convert.ToBoolean(row["IsAdmin"]);

                    if (isAdmin)
                        users.Add(new Admin(id, username, email, password));
                    else
                        users.Add(new User(id, username, email, password));
                }

                return users;
            }
        }

        public void RegisterUser(User user, string createdBy = "Self-Registered")
        {
            string query = @"INSERT INTO Users (Username, Email, Password, IsAdmin, CreatedBy)
                      VALUES (@Username, @Email, @Password, @IsAdmin, @CreatedBy)";

            DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@IsAdmin", user is Admin),
                new SqlParameter("@CreatedBy", createdBy));

            Console.WriteLine($"Registered User: {user.Username}");
        }

        // --- LISTINGS ---
        // NOTE: Listing has no Id property, so (ItemName + OwnerId) is used as the
        // natural key everywhere a specific row needs to be identified. This means
        // one user cannot have two listings with the exact same ItemName.


        public void DeleteAdmin(int id)
        {
            string query = "DELETE FROM Users WHERE Id = @Id";
            DatabaseHelper.ExecuteNonQuery(query, new SqlParameter("@Id", id));
        }
        public List<Listing> Listings
        {
            get
            {
                List<Listing> listings = new List<Listing>();
                DataTable dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Listings ORDER BY DatePosted DESC");
                List<User> users = Users;

                foreach (DataRow row in dt.Rows)
                {
                    Listing listing = BuildListingFromRow(row, users);
                    if (listing != null)
                        listings.Add(listing);
                }

                return listings;
            }
        }

        private Listing BuildListingFromRow(DataRow row, List<User> users)
        {
            int ownerId = Convert.ToInt32(row["OwnerId"]);
            User owner = users.Find(u => u.Id == ownerId);
            string category = row["Category"].ToString();

            Listing listing;

            if (category == "Book")
            {
                listing = new BookListing
                {
                    CourseCode = row["CourseCode"].ToString(),
                    Author = row["Author"].ToString(),
                    Edition = row["Edition"].ToString(),
                    Condition = row["Condition"].ToString()
                };
            }
            else if (category == "Equipment")
            {
                listing = new EquipmentListing
                {
                    EquipmentType = row["EquipmentType"].ToString(),
                    Condition = row["Condition"].ToString()
                };
            }
            else if (category == "Note")
            {
                listing = new NoteListing
                {
                    CourseCode = row["CourseCode"].ToString(),
                    Semester = row["Semester"].ToString(),
                    Format = row["Format"].ToString()
                };
            }
            else
            {
                return null;
            }

            listing.ItemName = row["ItemName"].ToString();
            listing.Description = row["Description"].ToString();
            listing.Owner = owner;
            listing.DatePosted = Convert.ToDateTime(row["DatePosted"]);
            listing.Status = (ListingStatus)Enum.Parse(typeof(ListingStatus), row["Status"].ToString());
            listing.ImageData = row["ImageData"] == DBNull.Value ? null : (byte[])row["ImageData"];

            return listing;
        }

        public void PostListing(Listing listing)
        {
            string category = listing is BookListing ? "Book"
                 : listing is EquipmentListing ? "Equipment"
                 : listing is NoteListing ? "Note"
                 : throw new ArgumentException("Unknown listing type");

            string query = @"INSERT INTO Listings
(ItemName, Description, OwnerId, DatePosted, Status, Category, CourseCode, Author, Edition, Condition, EquipmentType, Semester, Format, ImageData)
VALUES
(@ItemName, @Description, @OwnerId, @DatePosted, @Status, @Category, @CourseCode, @Author, @Edition, @Condition, @EquipmentType, @Semester, @Format, @ImageData)";

            DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@ItemName", listing.ItemName),
                new SqlParameter("@Description", (object)listing.Description ?? DBNull.Value),
                new SqlParameter("@OwnerId", listing.Owner.Id),
                new SqlParameter("@DatePosted", listing.DatePosted),
                new SqlParameter("@Status", listing.Status.ToString()),
                new SqlParameter("@Category", category),
                new SqlParameter("@CourseCode", (object)(listing as BookListing)?.CourseCode ?? (object)(listing as NoteListing)?.CourseCode ?? DBNull.Value),
                new SqlParameter("@Author", (object)(listing as BookListing)?.Author ?? DBNull.Value),
                new SqlParameter("@Edition", (object)(listing as BookListing)?.Edition ?? DBNull.Value),
                new SqlParameter("@Condition", (object)(listing as BookListing)?.Condition ?? (object)(listing as EquipmentListing)?.Condition ?? DBNull.Value),
                new SqlParameter("@EquipmentType", (object)(listing as EquipmentListing)?.EquipmentType ?? DBNull.Value),
                new SqlParameter("@Semester", (object)(listing as NoteListing)?.Semester ?? DBNull.Value),
                new SqlParameter("@Format", (object)(listing as NoteListing)?.Format ?? DBNull.Value),
                new SqlParameter("@ImageData", (object)listing.ImageData ?? DBNull.Value)   // <-- now inside the call, comma not semicolon
            );
        }
        public void UpdateListing(string originalItemName, int ownerId, Listing updatedListing)
        {
            DatabaseHelper.UpdateListing(originalItemName, ownerId, updatedListing);
            Console.WriteLine($"Listing updated: {originalItemName} -> {updatedListing.ItemName}");
        }

        public void DeleteListing(User actingUser, Listing listing)
        {
            if (!(actingUser is Admin))
            {
                Console.WriteLine($"{actingUser.Username} is not authorized to delete listings.");
                return;
            }

            string deleteRequests = @"DELETE tr FROM TransactionRequests tr
                               JOIN Listings l ON tr.ListingId = l.Id
                               WHERE l.ItemName = @ItemName AND l.OwnerId = @OwnerId";

            DatabaseHelper.ExecuteNonQuery(deleteRequests,
                new SqlParameter("@ItemName", listing.ItemName),
                new SqlParameter("@OwnerId", listing.Owner.Id));

            string query = "DELETE FROM Listings WHERE ItemName = @ItemName AND OwnerId = @OwnerId";
            DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@ItemName", listing.ItemName),
                new SqlParameter("@OwnerId", listing.Owner.Id));

            Console.WriteLine($"Admin {actingUser.Username} deleted listing: {listing.ItemName}");
        }

        public List<Listing> GetAvailableListings()
        {
            List<Listing> available = new List<Listing>();
            foreach (var listing in Listings)
            {
                if (listing.Status == ListingStatus.Available)
                    available.Add(listing);
            }
            return available;
        }

        // --- TRANSACTION REQUESTS ---
        // NOTE: matched by (RequesterId + ItemName + OwnerId) since neither
        // Listing nor TransactionRequest carries a database Id.

        public List<TransactionRequest> Requests
        {
            get
            {
                List<TransactionRequest> requests = new List<TransactionRequest>();
                List<User> users = Users;
                List<Listing> listings = Listings;

                string query = @"SELECT tr.RequesterId, tr.Status, tr.RequestDate, l.ItemName, l.OwnerId
                                  FROM TransactionRequests tr
                                  JOIN Listings l ON tr.ListingId = l.Id";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                foreach (DataRow row in dt.Rows)
                {
                    int requesterId = Convert.ToInt32(row["RequesterId"]);
                    int ownerId = Convert.ToInt32(row["OwnerId"]);
                    string itemName = row["ItemName"].ToString();

                    User requester = users.Find(u => u.Id == requesterId);
                    Listing listing = listings.Find(l => l.ItemName == itemName && l.Owner.Id == ownerId);

                    if (requester == null || listing == null) continue;

                    TransactionRequest request = new TransactionRequest(requester, listing);
                    request.Status = (TransactionStatus)Enum.Parse(typeof(TransactionStatus), row["Status"].ToString());
                    request.RequestDate = Convert.ToDateTime(row["RequestDate"]);
                    requests.Add(request);
                }

                return requests;
            }
        }


        public TransactionRequest RequestTransaction(User requester, Listing listing)
        {
            string query = @"INSERT INTO TransactionRequests (RequesterId, ListingId, Status, RequestDate)
                              SELECT @RequesterId, Id, 'Pending', SYSUTCDATETIME()
                              FROM Listings
                              WHERE ItemName = @ItemName AND OwnerId = @OwnerId";

            DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@RequesterId", requester.Id),
                new SqlParameter("@ItemName", listing.ItemName),
                new SqlParameter("@OwnerId", listing.Owner.Id));

            var request = new TransactionRequest(requester, listing);
            Console.WriteLine($"{requester.Username} requested {listing.ItemName}");
            return request;
        }

        public void AcceptRequest(User actingUser, TransactionRequest request)
        {
            if (!(actingUser is Admin))
            {
                Console.WriteLine($"{actingUser.Username} is not authorized to approve requests.");
                return;
            }

            string updateRequest = @"UPDATE tr
                                      SET tr.Status = 'Accepted'
                                      FROM TransactionRequests tr
                                      JOIN Listings l ON tr.ListingId = l.Id
                                      WHERE tr.RequesterId = @RequesterId
                                        AND l.ItemName = @ItemName AND l.OwnerId = @OwnerId
                                        AND tr.Status = 'Pending'";

            DatabaseHelper.ExecuteNonQuery(updateRequest,
                new SqlParameter("@RequesterId", request.Requester.Id),
                new SqlParameter("@ItemName", request.Listing.ItemName),
                new SqlParameter("@OwnerId", request.Listing.Owner.Id));

            string updateListing = @"UPDATE Listings SET Status = 'Reserved'
                                      WHERE ItemName = @ItemName AND OwnerId = @OwnerId";

            DatabaseHelper.ExecuteNonQuery(updateListing,
                new SqlParameter("@ItemName", request.Listing.ItemName),
                new SqlParameter("@OwnerId", request.Listing.Owner.Id));

            request.Status = TransactionStatus.Accepted;
            request.Listing.Status = ListingStatus.Reserved;
            Console.WriteLine($"Admin {actingUser.Username} accepted request from {request.Requester.Username} for {request.Listing.ItemName}");
        }

        public void RejectRequest(User actingUser, TransactionRequest request)
        {
            if (!(actingUser is Admin))
            {
                Console.WriteLine($"{actingUser.Username} is not authorized to reject requests.");
                return;
            }

            string query = @"UPDATE tr
                              SET tr.Status = 'Rejected'
                              FROM TransactionRequests tr
                              JOIN Listings l ON tr.ListingId = l.Id
                              WHERE tr.RequesterId = @RequesterId
                                AND l.ItemName = @ItemName AND l.OwnerId = @OwnerId
                                AND tr.Status = 'Pending'";

            DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@RequesterId", request.Requester.Id),
                new SqlParameter("@ItemName", request.Listing.ItemName),
                new SqlParameter("@OwnerId", request.Listing.Owner.Id));

            request.Status = TransactionStatus.Rejected;
            Console.WriteLine($"Admin {actingUser.Username} rejected request from {request.Requester.Username} for {request.Listing.ItemName}");
        }
    }
}