using DentistCalendar.Data.Entity;
using DentistCalendar.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using DentistCalendar.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Collections.Generic;
using DentistCalendar.Migrations;
using System.Threading.Tasks;
using shopapp.webui.Models;
using System;
using System.Drawing;

namespace DentistCalendar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
       

        private UserManager<AppUser> _userManager;
        private ApplicationDbContext _context;
        private RoleManager<AppRole> _roleManager;

        public AdminController(UserManager<AppUser> userManager, ApplicationDbContext context, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
      
             

      public IActionResult Comments()
        {
            var comments= _context.Comments.ToList();

            return View(comments);
        }

        public IActionResult ConfirmComments(int id)
        {
            var comments = _context.Comments.Where(i => i.Id == id).FirstOrDefault();

            comments.Confirm = true;
            _context.SaveChanges();
            return RedirectToAction("Comments");

        }

        public IActionResult DeleteComments(int id)
        {
            var comment=_context.Comments.Where(i=>i.Id==id).FirstOrDefault();

            if (comment!=null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }

            return RedirectToAction("Comments");
        }

        public IActionResult removeConfirm(int id)
        {
            var comment=_context.Comments.Where(i=>i.Id== id).FirstOrDefault(); 

            if (comment!=null)
            {
                comment.Confirm = false;
                _context.SaveChanges();
            }

            return RedirectToAction("Comments");
        }
        public IActionResult UserList()
        {
            return View(_userManager.Users);
        }

        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);
                var roles = _roleManager.Roles.Select(i => i.Name);
                var appointments=_context.Appointments.Where(i=>i.Tc==user.Tc && i.StartDate>=System.DateTime.Now).ToList();
                var sinceappointment=_context.Appointments.Where(i=>i.Tc==user.Tc && i.StartDate<System.DateTime.Now).ToList();
                ViewBag.Roles = roles;
                
                return View(new UserDetailsModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Name = user.Name,
                    Surname = user.Surname,
                    Tc = user.Tc,
                    Email = user.Email,
                    SelectedRoles = selectedRoles,
                    AktifRandevu=appointments,
                    GecmisRandevu=sinceappointment
                });

                
            }
            return Redirect("~/admin/user/list");
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserDetailsModel model, string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    user.Name = model.Name;
                    user.Surname = model.Surname;
                    user.UserName = model.UserName;
                    user.Tc = model.Tc;
                    user.Email = model.Email;

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        selectedRoles = selectedRoles ?? new string[] { };
                        await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles).ToArray<string>());

                        return Redirect("/admin/userlist");
                    }
                }
                return Redirect("/admin/user/list");
            }

            return View(model);

        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> AddRole(AddToRoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new AppRole(model.RoleName));
                if(result.Succeeded)
                {
                    return RedirectToAction("rolelist");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View("~/");
            }
         
        }


        public IActionResult DeleteRole(string id)
        {
            var role = _roleManager.Roles.Where(i => i.Id == id).FirstOrDefault();
            _context.Roles.Remove(role);
            _context.SaveChanges();
            return RedirectToAction("RoleList");
        }

        public async Task<IActionResult> RoleEdit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var members = new List<AppUser>();
            var nonmembers = new List<AppUser>();

            foreach (var user in _userManager.Users.ToList())
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name)
                                ? members : nonmembers;
                list.Add(user);
            }
            var model = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        if (model.RoleName == "Dentist")
                        {
                            
                            user.IsDentist = true;
                            var x = new Random().Next(100);
                            var y = new Random().Next(150);
                            var z = new Random().Next(200);

                            user.Color ="#"+Color.FromArgb(x, y, z).Name;
                        }
                        var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                     
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

                foreach (var userId in model.IdsToDelete ?? new string[] { })
                {
                    var appointment = _context.Appointments.ToList();
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        if (model.RoleName == "Dentist")
                        {
                            user.IsDentist = false;

                            foreach (var item in appointment)
                            {
                                if (item.UserId == userId)
                                {
                                    _context.Appointments.Remove(item);
                                    _context.SaveChanges();
                                }
                            }
                           
                        }
                        var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
            }
            return Redirect("/admin/role/" + model.RoleId);
        }

        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }

        public IActionResult Blogs()
        {
            var blogs = _context.Blogs.ToList();
          
            var doctors=_context.Users.ToList();
            ViewBag.Blogs = doctors;
            return View(blogs);
        }

        public IActionResult DeleteBlog(int id)
        {
            var blog=_context.Blogs.Where(i=>i.Id==id).FirstOrDefault();

            if (blog != null) {

                _context.Blogs.Remove(blog);
                _context.SaveChanges();
            }

            return RedirectToAction("blogs");
        }
    }
}
