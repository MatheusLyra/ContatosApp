﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContatosApp.Presentation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        /// <summary>
        /// Método para abrir a página /Home/Index
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
    }
}
