using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp_Project.Models;

namespace ToDoApp_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult login(string email,string pass)
        {
            var user = _context.User.FirstOrDefault(w =>w.Email.Equals(email)&& w.Password.Equals(pass));
            if (user != null)
            {
                HttpContext.Session.SetInt32("id", user.Id);
                HttpContext.Session.SetString("fullname", user.Name + " " + user.SurName);
                return Redirect("/Account/Index");
            }
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
        public async Task<ActionResult> Register(User model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return Redirect("Index");
        }
    }
}
