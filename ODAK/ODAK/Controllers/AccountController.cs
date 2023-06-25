using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DentistCalendar.Data;
using DentistCalendar.Data.Entity;
using DentistCalendar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DentistCalendar.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private RoleManager<AppRole> _roleManager;
        private ApplicationDbContext _context;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError(String.Empty, "Kullanıcı bulunamadı.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "user");
            }

            ModelState.AddModelError(String.Empty, "Oturum açmada bir hata oluştu.");
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AppUser user = new AppUser()
            {
                Tc = model.TC,
                UserName = model.UserName,
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                Color = model.Color,
                IsDentist = model.IsDentist,
                Pass=model.Password,
                PhoneNumber=model.PhoneNumber
                
            };

            IdentityResult result = _userManager.CreateAsync(user, model.Password).Result;

            if (result.Succeeded)
            {
                bool roleCheck = model.IsDentist ? AddRole("Dentist") : AddRole("Patient");
                if (!roleCheck)
                {
                    return View("Error");
                }
                _userManager.AddToRoleAsync(user, model.IsDentist ? "Dentist" : "Patient").Wait();
                return RedirectToAction("login");
            }

            return View("Error");
        }

        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("index","user");
        }

        public IActionResult Denied()
        {
            return View();
        }


        private bool AddRole(string roleName)
        {
            if (!_roleManager.RoleExistsAsync(roleName).Result)
            {
                AppRole role = new AppRole()
                {
                    Name = roleName
                };

                IdentityResult result = _roleManager.CreateAsync(role).Result;
                return result.Succeeded;
            }
            return true;
        }


        public IActionResult AccountSetting()
        {
            var user = _context.Users.Where(i => i.Id == _userManager.GetUserId(User)).FirstOrDefault();


            var model = new AccountSettingsViewModel()
            {
                Image=user.ImageUrl,
                Id=user.Id,
                Name = user.Name,
                Surname= user.Surname,
                Email= user.Email,
                TC=user.Tc,
                UserName= user.UserName,
                Password=user.Pass,
                PhoneNumber=user.PhoneNumber
            };

            return View(model);
        }


        [HttpPost]
        public async Task< IActionResult> AccountSettingUpdate(AccountSettingsViewModel model)
        {

            var entity = _context.Users.Where(i=>i.Id==model.Id).FirstOrDefault();

            if (entity == null)
            {
                return View(model);
            }
            else
            {
                if(model.ImageUrl== null)
                {
                    if (entity.UserName != model.UserName)
                    {

                        entity.Pass = model.Password;
                        entity.Surname = model.Surname;
                        entity.Email = model.Email;
                        entity.Name = model.Name;
                        entity.UserName = model.UserName;
                        entity.Tc = model.TC;
                        entity.PhoneNumber = model.PhoneNumber;
                        entity.PasswordHash = _userManager.PasswordHasher.HashPassword(entity, model.Password);



                        await _userManager.UpdateAsync(entity);

                        return RedirectToAction("logout");
                    }
                    else
                    {

                        entity.Pass = model.Password;
                        entity.Surname = model.Surname;
                        entity.Email = model.Email;
                        entity.Name = model.Name;
                        entity.UserName = model.UserName;
                        entity.Tc = model.TC;
                        entity.PasswordHash = _userManager.PasswordHasher.HashPassword(entity, model.Password);
                        entity.PhoneNumber = model.PhoneNumber;


                        await _userManager.UpdateAsync(entity);

                        return RedirectToAction("AccountSetting");
                    }
                }

                else
                {
                    if(entity.UserName!=model.UserName)
                    {
                        var extension = Path.GetExtension(model.ImageUrl.FileName);
                        var newImageName = Guid.NewGuid() + extension;
                        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", newImageName);
                        var stream = new FileStream(location, FileMode.Create);
                        model.ImageUrl.CopyTo(stream);
                        entity.ImageUrl = newImageName;
                        entity.PhoneNumber= model.PhoneNumber;
                        entity.Pass = model.Password;
                        entity.Surname = model.Surname;
                        entity.Email = model.Email;
                        entity.Name = model.Name;
                        entity.UserName = model.UserName;
                        entity.Tc = model.TC;
                        entity.PasswordHash = _userManager.PasswordHasher.HashPassword(entity, model.Password);



                        await _userManager.UpdateAsync(entity);


                        return RedirectToAction("logout");
                    }
                    else
                    {
                        var extension = Path.GetExtension(model.ImageUrl.FileName);
                        var newImageName = Guid.NewGuid() + extension;
                        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", newImageName);
                        var stream = new FileStream(location, FileMode.Create);
                        model.ImageUrl.CopyTo(stream);
                        entity.ImageUrl = newImageName;
                        entity.PhoneNumber = model.PhoneNumber;
                        entity.Pass = model.Password;
                        entity.Surname = model.Surname;
                        entity.Email = model.Email;
                        entity.Name = model.Name;
                        entity.UserName = model.UserName;
                        entity.Tc = model.TC;
                        entity.PasswordHash = _userManager.PasswordHasher.HashPassword(entity, model.Password);



                        await _userManager.UpdateAsync(entity);


                        return RedirectToAction("AccountSetting");
                    }
                   
                }
                
            }

    
        }


        public IActionResult DeleteImage(string id)
        {
            var user = _context.Users.Where(i => i.UserName == id).FirstOrDefault();
            user.ImageUrl = null;
            _context.SaveChanges();

            return RedirectToAction("accountsetting");
        }
    }
}