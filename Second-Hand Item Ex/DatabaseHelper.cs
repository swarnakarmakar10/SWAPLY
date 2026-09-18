using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CampusMarketPlace
{
    public static class DatabaseHelper
    {
        public static string ConnectionString =
    ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;

        public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                con.Open();
                return cmd.ExecuteScalar();
            }
        }
        public static void InsertUser(User user, bool isAdmin)
        {
            string query = "INSERT INTO Users (Username, Email, Password, IsAdmin) VALUES (@Username, @Email, @Password, @IsAdmin)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Username", user.Username),
        new SqlParameter("@Email", user.Email),
        new SqlParameter("@Password", user.Password),
        new SqlParameter("@IsAdmin", isAdmin)
            };

            ExecuteNonQuery(query, parameters);
        }
        public static User GetUserByCredentials(string username, string password)
        {
            string query = "SELECT Id, Username, Email, Password, IsAdmin FROM Users WHERE Username=@Username AND Password=@Password";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Username", username),
        new SqlParameter("@Password", password)
            };

            DataTable dt = ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];
            int id = Convert.ToInt32(row["Id"]);
            string email = row["Email"].ToString();
            bool isAdmin = Convert.ToBoolean(row["IsAdmin"]);

            if (isAdmin)
                return new Admin(id, username, email, password);
            else
                return new User(id, username, email, password);
        }
        public static void InsertBookListing(BookListing listing)
        {
            string query = "INSERT INTO BookListings (ItemName, Description, OwnerId, DatePosted, Status, CourseCode, Author, Edition, Condition) VALUES (@ItemName, @Description, @OwnerId, @DatePosted, @Status, @CourseCode, @Author, @Edition, @Condition)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@ItemName", listing.ItemName),
        new SqlParameter("@Description", listing.Description),
        new SqlParameter("@OwnerId", listing.Owner.Id),
        new SqlParameter("@DatePosted", listing.DatePosted),
        new SqlParameter("@Status", listing.Status.ToString()),
        new SqlParameter("@CourseCode", listing.CourseCode),
        new SqlParameter("@Author", listing.Author),
        new SqlParameter("@Edition", listing.Edition),
        new SqlParameter("@Condition", listing.Condition)
            };

            ExecuteNonQuery(query, parameters);
        }

        public static void InsertEquipmentListing(EquipmentListing listing)
        {
            string query = "INSERT INTO EquipmentListings (ItemName, Description, OwnerId, DatePosted, Status, EquipmentType, Condition) VALUES (@ItemName, @Description, @OwnerId, @DatePosted, @Status, @EquipmentType, @Condition)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@ItemName", listing.ItemName),
        new SqlParameter("@Description", listing.Description),
        new SqlParameter("@OwnerId", listing.Owner.Id),
        new SqlParameter("@DatePosted", listing.DatePosted),
        new SqlParameter("@Status", listing.Status.ToString()),
        new SqlParameter("@EquipmentType", listing.EquipmentType),
        new SqlParameter("@Condition", listing.Condition)
            };

            ExecuteNonQuery(query, parameters);
        }

        public static void InsertNoteListing(NoteListing listing)
        {
            string query = "INSERT INTO NoteListings (ItemName, Description, OwnerId, DatePosted, Status, CourseCode, Semester, Format) VALUES (@ItemName, @Description, @OwnerId, @DatePosted, @Status, @CourseCode, @Semester, @Format)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@ItemName", listing.ItemName),
        new SqlParameter("@Description", listing.Description),
        new SqlParameter("@OwnerId", listing.Owner.Id),
        new SqlParameter("@DatePosted", listing.DatePosted),
        new SqlParameter("@Status", listing.Status.ToString()),
        new SqlParameter("@CourseCode", listing.CourseCode),
        new SqlParameter("@Semester", listing.Semester),
        new SqlParameter("@Format", listing.Format)
            };

            ExecuteNonQuery(query, parameters);
        }

        public static void UpdateListing(string originalItemName, int ownerId, Listing listing)
        {
            string query = @"UPDATE Listings SET
        ItemName = @NewItemName,
        Description = @Description,
        CourseCode = @CourseCode,
        Author = @Author,
        Edition = @Edition,
        Condition = @Condition,
        EquipmentType = @EquipmentType,
        Semester = @Semester,
        Format = @Format,
        ImageData = @ImageData
    WHERE ItemName = @OriginalItemName AND OwnerId = @OwnerId";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NewItemName", listing.ItemName),
                new SqlParameter("@Description", (object)listing.Description ?? DBNull.Value),
                new SqlParameter("@CourseCode", (object)(listing as BookListing)?.CourseCode ?? (object)(listing as NoteListing)?.CourseCode ?? DBNull.Value),
                new SqlParameter("@Author", (object)(listing as BookListing)?.Author ?? DBNull.Value),
                new SqlParameter("@Edition", (object)(listing as BookListing)?.Edition ?? DBNull.Value),
                new SqlParameter("@Condition", (object)(listing as BookListing)?.Condition ?? (object)(listing as EquipmentListing)?.Condition ?? DBNull.Value),
                new SqlParameter("@EquipmentType", (object)(listing as EquipmentListing)?.EquipmentType ?? DBNull.Value),
                new SqlParameter("@Semester", (object)(listing as NoteListing)?.Semester ?? DBNull.Value),
                new SqlParameter("@Format", (object)(listing as NoteListing)?.Format ?? DBNull.Value),
                new SqlParameter("@ImageData", (object)listing.ImageData ?? DBNull.Value) 
            };
        }
        
        public static void InsertTransactionRequest(TransactionRequest request, string listingType)
        {
            string query = "INSERT INTO TransactionRequests (RequesterId, ListingItemName, ListingOwnerId, ListingType, Status, RequestDate) VALUES (@RequesterId, @ListingItemName, @ListingOwnerId, @ListingType, @Status, @RequestDate)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@RequesterId", request.Requester.Id),
        new SqlParameter("@ListingItemName", request.Listing.ItemName),
        new SqlParameter("@ListingOwnerId", request.Listing.Owner.Id),
        new SqlParameter("@ListingType", listingType),
        new SqlParameter("@Status", request.Status.ToString()),
        new SqlParameter("@RequestDate", request.RequestDate)
            };

            ExecuteNonQuery(query, parameters);
        }
    }
}