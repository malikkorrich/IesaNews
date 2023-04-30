using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IesaNews.Repository
{
  public  interface IStaticRepository
    {
        int getTotalUsers();
        int getTotalArticles();
        int getTotalContact();
    }
}
