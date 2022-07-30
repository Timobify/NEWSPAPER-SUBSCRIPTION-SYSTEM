using System;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Models.NewsPapers;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Models.Users;

namespace NEWSPAPER_SUBSCRIPTION_SYSTEM.Models.Subscriptions
{
    public class SubscriptionModel
    {
        public int SubId { get; set; }
        public int UserId { get; set; }
        public UpdateModel Users { get; set; }
        public int NewsPaperId { get; set; }
        public NewsPaperModel NewsPapers { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public decimal Cost { get; set; }
        public string Status { get; set; }
    }
}