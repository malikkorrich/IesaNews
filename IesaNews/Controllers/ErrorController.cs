using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IesaNews.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
         public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode) {
                case 404: ViewBag.errorMessage = "404 Not Found";

                        break;

            }
        return View("NotFound");
        }
    }
}