using System;
using System.Collections.Generic;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Entities;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Helpers;

namespace NEWSPAPER_SUBSCRIPTION_SYSTEM.Services
{
    public interface ISubscriptionService
    {
        IEnumerable<Subscription> GetAll();
        Subscription GetById(int subid);
        Subscription Create(Subscription subscription);
        void Update(Subscription subscription);
        void Delete(int subid);
    }
    
    public class SubscriptionService : ISubscriptionService
    {
        private DataContext _context;

        public SubscriptionService(DataContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Subscription> GetAll()
        {
            return _context.Subscriptions;
        }

        public Subscription GetById(int subid)
        {
            return _context.Subscriptions.Find(subid);
        }

        public Subscription Create(Subscription subscription)
        {
            _context.Subscriptions.Add(subscription);
            _context.SaveChanges();

            return subscription;
        }

        public void Update(Subscription subParams)
        {
            var subscription = _context.Subscriptions.Find(subParams.SubId);

            if (subscription == null)
            {
                throw new AppException("Subscription not found");
            }

            if (!String.IsNullOrEmpty(subParams.UserId.ToString()))
            {
                subscription.UserId = subParams.UserId;
            }
            
            if (!String.IsNullOrEmpty(subParams.NewsPaperId.ToString()))
            {
                subscription.NewsPaperId = subParams.NewsPaperId;
            }
            
            if (subParams.Start_Date == DateTime.MinValue)
            {
                subscription.Start_Date = subParams.Start_Date;
            }
            if (subParams.End_Date == DateTime.MinValue)
            {
                subscription.End_Date = subParams.End_Date;
            }
            if (!subParams.Cost.Equals(null))
            {
                subscription.Cost = subParams.Cost;
            }
            if (!string.IsNullOrWhiteSpace(subParams.Status))
                subscription.Status = subParams.Status;
            _context.Subscriptions.Update(subscription);
            _context.SaveChanges();
        }

        public void Delete(int subid)
        {
            var subscription = _context.Subscriptions.Find(subid);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
                _context.SaveChanges();
            }
        }
    }
}