using System;
using System.Collections.Generic;
using System.Linq;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Entities;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Helpers;

namespace NEWSPAPER_SUBSCRIPTION_SYSTEM.Services
{
    public interface INewsPaperService
    {
        IEnumerable<NewsPaper> GetAll();
        NewsPaper GetById(int newsId);
        NewsPaper Create(NewsPaper newsPaper);
        void Update(NewsPaper newsPaper);
        void Delete(int newsId);
    }

    public class NewsPaperService : INewsPaperService
    {
        private DataContext _context;

        public NewsPaperService(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<NewsPaper> GetAll()
        {
            return _context.NewsPapers;
        }

        public NewsPaper GetById(int newsId)
        {
            return _context.NewsPapers.Find(newsId);
        }

        public NewsPaper Create(NewsPaper newsPaper)
        {
            if (_context.NewsPapers.Any(x => x.Name == newsPaper.Name))
            {
                throw new AppException("Name" + newsPaper.Name + " is already created");
            }

            _context.NewsPapers.Add(newsPaper);
            _context.SaveChanges();

            return newsPaper;
        }

        public void Update(NewsPaper newsParams)
        {
            var newspaper = _context.NewsPapers.Find(newsParams.NewsId);

            if (newspaper == null)
            {
                throw new AppException("Newspaper not found");
            }

            if (!string.IsNullOrWhiteSpace(newsParams.Name) && newsParams.Name != newspaper.Name)
            {
                if (_context.NewsPapers.Any(x => x.Name == newsParams.Name))
                    throw new AppException("Name " + newsParams.Name + " is already taken");
                newspaper.Name = newsParams.Name;
            }

            if (!newsParams.Fee.Equals(null))
            {
                newspaper.Fee = newsParams.Fee;
            }

            _context.NewsPapers.Update(newspaper);
            _context.SaveChanges();
        }

        public void Delete(int newsId)
        {
            var newspaper = _context.NewsPapers.Find(newsId);
            if (newspaper != null)
            {
                _context.NewsPapers.Remove(newspaper);
                _context.SaveChanges();
            }
        }
    }
}