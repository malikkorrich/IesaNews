using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegistroLogin.Filters;

namespace IesaNews.Controllers
{
    public class SettingController : Controller
    {
        [AuthorizeUsers]
        public IActionResult Index()
        {
            return RedirectToAction("list","user");
        }


 


    }
}
