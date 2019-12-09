using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AsteroidDodge.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AsteroidDodge.Controllers
{
    public class OverviewController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

    }
}
