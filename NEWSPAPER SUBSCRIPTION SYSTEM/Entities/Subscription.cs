using System;

namespace NEWSPAPER_SUBSCRIPTION_SYSTEM.Entities
{
    public class Subscription
    {
        public int SubId { get; set; }
        public int UserId { get; set; }
        public User Users { get; set; }
        public int NewsPaperId { get; set; }
        public NewsPaper NewsPapers { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public decimal Cost { get; set; }
        public string Status { get; set; }
    }
}