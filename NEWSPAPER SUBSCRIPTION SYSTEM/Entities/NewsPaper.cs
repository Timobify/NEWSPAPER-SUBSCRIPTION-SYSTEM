using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NEWSPAPER_SUBSCRIPTION_SYSTEM.Entities
{
    public class NewsPaper
    {
        [Key]
        public int NewsId { get; set; }
        public string Name { get; set; }
        public decimal Fee { get; set; }
        public IList<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}