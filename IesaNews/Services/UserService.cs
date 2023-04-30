using IesaNews.Context;
using IesaNews.Models;
using IesaNews.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IesaNews.Services
{
    public class UserService : IUserRepository
       
    {
        private readonly NewsContext newsContext;

        public UserService(NewsContext _newsContext) {
            newsContext = _newsContext;
        }

        public void add(User user)
        {
            newsContext.users.Add(user);
            newsContext.SaveChanges();
        }



        public void delete(int id)
        {
            newsContext.users.Remove(getById(id));
            newsContext.SaveChanges();
        }

        public void edit(User user)
        {
            
        }

        public List<User> getAll()
        {
            List<User> users = (from userObj in newsContext.users select userObj).ToList();
            return users;
        }

        public User getById(int id)
        {
            User user = (from userObj in newsContext.users where userObj.Id == id select userObj).FirstOrDefault();
            return user;

        }
        public User getByUsername(string username)
        {
            User user = (from userObj in newsContext.users where userObj.usuario == username select userObj).FirstOrDefault();
            return user;
        }

        public string getPassword()
        {
            string password = (from userObj in newsContext.users select userObj.password).FirstOrDefault();
            return password;
        }

        public User login(string username, string email)
        {
            User user = (from userObj in newsContext.users where userObj.usuario == username && userObj.email == email select userObj).FirstOrDefault();
            if (user != null)
                return user;
            else return null;
        }

        public bool checkEmail(string email)
        {
            User user = (from userObj in newsContext.users where userObj.email == email select userObj).FirstOrDefault();
            if (user != null)
                return true;
            else return false;
        }

        public bool checkUsername(string username)
        {
            User user = (from userObj in newsContext.users where userObj.usuario == username select userObj).FirstOrDefault();
            if (user != null)
                return true;
            else return false;
        }
    }
}
