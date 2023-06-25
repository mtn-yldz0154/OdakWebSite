using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentistCalendar.Data;
using DentistCalendar.Data.Entity;
using DentistCalendar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DentistCalendar.Controllers
{
    [Authorize]
    public class userProfileController : Controller
    {
        private UserManager<AppUser> _userManager;
        private ApplicationDbContext _context;
        public userProfileController(UserManager<AppUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index(string id)
        {
            AppUser user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);

            if (user == null)
            {
                return View("Error");
            }


            if (_userManager.IsInRoleAsync(user, "patient").Result)
            {
                ViewBag.id = id;
                var dentists = _userManager.Users.Where(x =>x.IsDentist);
                
         
                SecretaryViewModel model = new SecretaryViewModel()
                {
                 
                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                   
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem { 
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),
                  
                };
                return View("Secretary", model);
            }
            else
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {
                    
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList()
                };
                return View("Dentist", model);
            }

        }

        public IActionResult Secretary()
        {
            return View();
        }

        [Authorize(Roles = "Dentist")]
        public IActionResult Dentist()
        {
            return View();
        }
    }
}



