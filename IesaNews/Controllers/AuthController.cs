using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IesaNews.Models;
using IesaNews.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

using  Microsoft.AspNetCore.Http;
using RegistroLogin.Filters;

namespace IesaNews.Controllers
{
    public class AuthController : Controller
    {

        private readonly IUserRepository userRepository;

        public AuthController(IUserRepository _userRepository) {
            userRepository = _userRepository;
                }
        public IActionResult Register()
        {

            if (User.Identity.IsAuthenticated)
            {
                // User is authenticated, do something
                return RedirectToAction("dashboard");
            }
            else
            {
                // User is not authenticated, redirect to login page
                return View();
            }
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            userRepository.add(user);
            return RedirectToAction("Login");
        }


        public IActionResult Login()
        {

            if (User.Identity.IsAuthenticated)
            {
                // User is authenticated, do something
                return RedirectToAction("dashboard");
            }
            else
            {
                // User is not authenticated, redirect to login page
                return View();
            }
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            string password = userRepository.getPassword();
            bool flag = userRepository.checkUsername(user.usuario) && password.Equals(user.password) ;
          
            User usuario = userRepository.getByUsername(user.usuario);

            if (usuario == null || !flag)
            {
                ViewData["message"] = "No tienes credentiales correctas";
                return View();
            }
            else {
                //Debemos crear una identidad (name y role)
                //y un principal
                //dicha identidad debemos combinarla con la cookie de authentificacion
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme,ClaimTypes.Name,ClaimTypes.Role);
                //todo usuario puede contener una serie de caracterisiticas
                //llmada clamis dichas caracterisitcas podemos almacenarlas
                //dentro de user para utilizarlas a lo largo de la app
                Claim claimUsername = new Claim(ClaimTypes.Name, usuario.name);
                Claim claimRole = new Claim(ClaimTypes.Role, usuario.type);
                Claim claimIdUsuario = new Claim("IdUsuario", usuario.Id.ToString());
                Claim ClaimEmail = new Claim("EmailUsuario", usuario.email);

                identity.AddClaim(claimUsername);
                identity.AddClaim(claimRole);
                identity.AddClaim(claimIdUsuario);
                identity.AddClaim(ClaimEmail);

                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(identity);

            

                 HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,userPrincipal, new AuthenticationProperties { 
                    ExpiresUtc = DateTime.Now.AddMinutes(45)
                });


 
            }
               return RedirectToAction("Dashboard","Auth");
           
        }

        [AuthorizeUsers]
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult ErrorAcceso() {
            ViewData["message"] = "Error de Acceso";
            return View();
        }

        [AuthorizeUsers]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("login", "Auth");
        }
    }
}