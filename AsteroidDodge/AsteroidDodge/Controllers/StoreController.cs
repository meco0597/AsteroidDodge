using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace AsteroidDodge.Controllers
{
    public class StoreController : Controller
    {
        // GET: /Store/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult skinChange(string skin)
        {
            //var user = _usermanager.FindByEmailAsync(user_name).Result;
            //var currRole = _rolemanager.FindByNameAsync(role).Result.Name;
            //bool add = add_remove.Equals("true");
            //if (currRole == "admin" && !add)
            //{
            //    int admin = 0;
            //    foreach (var usr in _usermanager.Users)
            //    {
            //        if (_usermanager.IsInRoleAsync(usr, "admin").Result)
            //        {
            //            admin++;
            //        }
            //    }
            //    if (admin < 2)
            //    {
            //        return BadRequest(new JsonResult(new
            //        { success = false, message = "Only one admin left. Cant change role." }));
            //    }
            //}
            //var userStore = new UserStore<IdentityUser>(_idcontext);
            //if (add)
            //{
            //    _usermanager.AddToRoleAsync(user, currRole);
            //    userStore.AddToRoleAsync(user, currRole);
            //}
            //else
            //{
            //    _usermanager.RemoveFromRoleAsync(user, currRole);
            //    userStore.RemoveFromRoleAsync(user, currRole);
            //}
            //_idcontext.SaveChanges();


            return new JsonResult(new { success = true });

        }
    }
}
