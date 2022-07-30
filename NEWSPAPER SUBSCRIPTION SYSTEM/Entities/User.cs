using System.Collections.Generic;

namespace NEWSPAPER_SUBSCRIPTION_SYSTEM.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public IList<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}