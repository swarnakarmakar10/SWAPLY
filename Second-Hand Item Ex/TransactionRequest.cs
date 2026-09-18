using System;
using System.Collections.Generic;
using System.Text;

namespace CampusMarketPlace
{
    public enum TransactionStatus
    {
        Pending,
        Accepted,
        Rejected
    }
    public class TransactionRequest
    {
        public User Requester { get; set; }
        public Listing Listing { get; set; }
        public TransactionStatus Status{ get; set; }
        public DateTime RequestDate { get; set; }
     
        
        public TransactionRequest(User requester, Listing listing)
        {
            Requester = requester;
            Listing = listing;
            Status = TransactionStatus.Pending;
            RequestDate = DateTime.Now;


        }
        public override string ToString()
        {
            return $"TransactionRequest[Requester= {Requester}, Item = {Listing.ItemName}, Status= {Status}, Date= {RequestDate}]";
        }
    }
}
