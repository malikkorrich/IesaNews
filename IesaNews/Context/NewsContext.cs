using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IesaNews.Models;
using Microsoft.Extensions.Configuration;

namespace IesaNews.Context
{
    public class NewsContext:DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options)
         : base(options)
        {
        }

        public DbSet<News> news { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<ContactUs> contactUs { get; set; }
        public DbSet<TeamMember> teamMembers { get; set; }

        public DbSet<User> users { get; set; }




    }
}
