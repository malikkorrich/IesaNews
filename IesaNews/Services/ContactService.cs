using IesaNews.Context;
using IesaNews.Models;
using IesaNews.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IesaNews.Services
{
    public class ContactService : IContactRepository
    {
        private readonly NewsContext newsContext;

        public ContactService(NewsContext _newsContext)
        {
            newsContext = _newsContext;
        }

        public void delete(int id)
        {
            ContactUs contact = (from contactObj in newsContext.contactUs where contactObj.Id == id select contactObj).FirstOrDefault();
            newsContext.contactUs.Remove(contact);
            newsContext.SaveChanges();
        }

        public List<ContactUs> getAll()
        {
            List<ContactUs> contacts = (from contactObj in newsContext.contactUs select contactObj).ToList();

            return contacts;
        }

        public  void save(ContactUs contact)
        {
            newsContext.contactUs.Add(contact);
            newsContext.SaveChanges();
        }
    }
}
