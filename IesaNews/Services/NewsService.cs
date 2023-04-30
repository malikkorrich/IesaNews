using IesaNews.Context;
using IesaNews.Models;
using IesaNews.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IesaNews.Services
{
    public class NewsService:INewsRepository
    {
        private readonly NewsContext newsContext;


        public NewsService(NewsContext _newsContext)
        {
            newsContext = _newsContext;
        }

        public void add(News news)
        {
            newsContext.news.Add(news);
            newsContext.SaveChanges();
        }

        public void delete(int id)
        {
            News news = (from newsObj in newsContext.news where newsObj.Id == id select newsObj).FirstOrDefault();
            newsContext.news.Remove(news);
            newsContext.SaveChanges();
        }

        public void edit(News news, int id)
        {
            //News newsObj = (from newObj in newsContext.news where newObj.Id == id select newObj).FirstOrDefault();
           //  newsContext.news.Remove(news);
            newsContext.news.Update(news);
           
            newsContext.SaveChanges();
        }

        public List<News> getAll()
        {
            try {
                List<News> news = (from newsObj in newsContext.news select newsObj).ToList();

                return news;
            
            } catch (Exception ex) {
                string srr = ex.Message;
                return null;
            }

          
        }

        public List<News> getByCategory(int id)
        {
            try
            {
                List<News> news = (from newsObj in newsContext.news where newsObj.categoryId == id select newsObj).ToList();

                return news;

            }
            catch (Exception ex)
            {
                string srr = ex.Message;
                return null;
            }
        }

        public News getById(int id)
        {
            News news = (from newsObj in newsContext.news where newsObj.Id == id select newsObj).FirstOrDefault();
            return news;
        }

        public List<News> getByUser(int id)
        {
            List<News> news = (from newsObj in newsContext.news where newsObj.usuarioId == id select newsObj).ToList();

            return news;
        }
    }
}
