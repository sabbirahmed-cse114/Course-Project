﻿using Microsoft.AspNetCore.Mvc;

namespace iTransition.Forms.Web.Areas.User.Controllers
{
    [Area("User")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
