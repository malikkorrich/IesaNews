using IesaNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IesaNews.Repository
{
   public interface INewsRepository
    {
        List<News> getAll();

        List<News> getByUser(int id);

        News getById(int id);

        List<News> getByCategory(int id);
        void add(News news);

        void delete(int id);

        void edit(News news, int id);
    }
}
