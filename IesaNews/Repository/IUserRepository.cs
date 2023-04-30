using IesaNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IesaNews.Repository
{
    public interface IUserRepository
    {
        List<User> getAll();
        void delete(int id);

        void edit(User user);

        User getById(int id);

        void add(User user);

        User getByUsername(string username);

        bool checkUsername(string username);
        bool checkEmail(string email);

        User login(string username, string email);

        string getPassword();


    }
}
