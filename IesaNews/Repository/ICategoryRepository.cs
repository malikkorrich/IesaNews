using IesaNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IesaNews.Repository
{
    public interface ICategoryRepository
    {
          List<Category> getAll();

        void edit(Category category);
        void delete(Category category);


        void add(Category category);
        Category getById(int id);
    }


}
