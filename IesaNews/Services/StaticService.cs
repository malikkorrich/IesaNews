using IesaNews.Context;
using IesaNews.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IesaNews.Services
{
    public class StaticService:IStaticRepository
    {
        public readonly NewsContext newsContext;

        public StaticService(NewsContext _newsContext) {
            newsContext = _newsContext;
        }

        public int getTotalArticles()
        {
            int total = (from newsObj in newsContext.news select newsObj).Count();
            return total;
        }

        public int getTotalContact()
        {
            int total = (from contactObj in newsContext.contactUs select contactObj).Count();
            return total;
        }

        public int getTotalUsers()
        {
            int total = (from userObj in newsContext.users select userObj).Count();
            return total;
        }
    }
}
