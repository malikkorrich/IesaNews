using IesaNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IesaNews.Repository
{
    public interface IContactRepository
    {
         void save(ContactUs contact);

        List<ContactUs> getAll();

        void delete(int id);

    }
}
