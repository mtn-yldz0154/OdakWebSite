using DentistCalendar.Data;
using DentistCalendar.Data.Entity;
using DentistCalendar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace DentistCalendar.Controllers
{
    public class UserController : Controller
    {
        private UserManager<AppUser> _userManager;
        private ApplicationDbContext _context;
        public UserController(UserManager<AppUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public  IActionResult Index()
        {
            var models = _userManager.Users.Where(i => i.IsDentist! && i.IsSecretary!);
            AppUser user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            var doctors = _context.Users.Where(i => i.IsDentist).ToList();
            var comments = _context.Comments.Where(i => i.Confirm).ToList();
            var blogs=_context.Blogs.ToList();

            if (!User.Identity.IsAuthenticated)
            {

                ViewBag.doctors = doctors;
                ViewBag.blogs = blogs;
                ViewBag.comments = comments;
                return View();
            }
            if (_userManager.IsInRoleAsync(user, "patient").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
         
                SecretaryViewModel model = new SecretaryViewModel()
                {
                   
                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                  
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                
                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                ViewBag.blogs = blogs;
                return View(model);
            }

            if (_userManager.IsInRoleAsync(user, "secretary").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;
                ViewBag.blogs = blogs;
                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "dentist").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;
                ViewBag.blogs = blogs;
                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "admin").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;
                ViewBag.blogs = blogs;
                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                return View(model);
            }


            return View();

        }

        public IActionResult About()
        {
            var models = _userManager.Users.Where(i => i.IsDentist! && i.IsSecretary!);
            AppUser user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            var doctors = _context.Users.Where(i => i.IsDentist).ToList();
            var comments = _context.Comments.Where(i => i.Confirm).ToList();

            if (!User.Identity.IsAuthenticated)
            {

                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View();
            }
            if (_userManager.IsInRoleAsync(user, "patient").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);

                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,

                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };

                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                return View(model);
            }

            if (_userManager.IsInRoleAsync(user, "secretary").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "dentist").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "admin").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                return View(model);
            }


            return View();

        }

        public IActionResult Work()
        {
            var models = _userManager.Users.Where(i => i.IsDentist! && i.IsSecretary!);
            AppUser user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            var doctors = _context.Users.Where(i => i.IsDentist).ToList();
            var comments = _context.Comments.Where(i => i.Confirm).ToList();

            if (!User.Identity.IsAuthenticated)
            {

                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View();
            }
            if (_userManager.IsInRoleAsync(user, "patient").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);

                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,

                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };

                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                return View(model);
            }

            if (_userManager.IsInRoleAsync(user, "secretary").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "dentist").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "admin").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                return View(model);
            }


            return View();

        }

        public IActionResult Online()
        {
            var models = _userManager.Users.Where(i => i.IsDentist! && i.IsSecretary!);
            AppUser user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            var doctors = _context.Users.Where(i => i.IsDentist).ToList();
            var comments = _context.Comments.Where(i => i.Confirm).ToList();

            if (!User.Identity.IsAuthenticated)
            {

                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View();
            }
            if (_userManager.IsInRoleAsync(user, "patient").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);

                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,

                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };

                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                return View(model);
            }

            if (_userManager.IsInRoleAsync(user, "secretary").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "dentist").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "admin").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                return View(model);
            }


            return View();

        }

        public IActionResult Test()
        {
            var models = _userManager.Users.Where(i => i.IsDentist! && i.IsSecretary!);
            AppUser user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            var doctors = _context.Users.Where(i => i.IsDentist).ToList();
            var comments = _context.Comments.Where(i => i.Confirm).ToList();

            if (!User.Identity.IsAuthenticated)
            {

                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View();
            }
            if (_userManager.IsInRoleAsync(user, "patient").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);

                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,

                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };

                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                return View(model);
            }

            if (_userManager.IsInRoleAsync(user, "secretary").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "dentist").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "admin").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                return View(model);
            }


            return View();

        }

      public IActionResult Randevu()
        {
            var models = _userManager.Users.Where(i => i.IsDentist! && i.IsSecretary!);
            AppUser user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            var doctors = _context.Users.Where(i => i.IsDentist).ToList();
            var comments = _context.Comments.Where(i => i.Confirm).ToList();

            if (!User.Identity.IsAuthenticated)
            {

                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View();
            }
            if (_userManager.IsInRoleAsync(user, "patient").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);

                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,

                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };

                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                return View(model);
            }

            if (_userManager.IsInRoleAsync(user, "secretary").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "dentist").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "admin").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                return View(model);
            }


            return View();

        }

        public IActionResult RandevuDetay()
        {
            var models = _userManager.Users.Where(i => i.IsDentist! && i.IsSecretary!);
            AppUser user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            var doctors = _context.Users.Where(i => i.IsDentist).ToList();
            var comments = _context.Comments.Where(i => i.Confirm).ToList();

            if (!User.Identity.IsAuthenticated)
            {

                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View();
            }
            if (_userManager.IsInRoleAsync(user, "patient").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);

                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,

                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };

                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                return View(model);
            }

            if (_userManager.IsInRoleAsync(user, "secretary").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "dentist").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "admin").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                return View(model);
            }


            return View();

        }

        [HttpPost]
        public IActionResult AddComment(SecretaryViewModel model)
        {

            Comment cm = new Comment()
            {
                Description = model.CommentViewModel.Description,
                Name = model.CommentViewModel.Name,
                Surname = model.CommentViewModel.Surname,
                Title = model.CommentViewModel.Title,
                Puan = model.CommentViewModel.Puan,
                Confirm = model.CommentViewModel.Confirm,

            };

            _context.Comments.Add(cm);
            _context.SaveChanges();
            TempData["messageComment"] = $"Mesajınız Başarıyla Gönderildi!";
       
            return Redirect("/user/index#comment");







        }
        public IActionResult Blog()
        {
            var models = _userManager.Users.Where(i => i.IsDentist! && i.IsSecretary!);
            AppUser user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            var doctors = _context.Users.Where(i => i.IsDentist).ToList();
            var comments = _context.Comments.Where(i => i.Confirm).ToList();
            var blogs = _context.Blogs.ToList();

            if (!User.Identity.IsAuthenticated)
            {

                ViewBag.doctors = doctors;
                ViewBag.blogs = blogs;
                ViewBag.comments = comments;
                return View();
            }
            if (_userManager.IsInRoleAsync(user, "patient").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);

                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,

                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };

                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                ViewBag.blogs = blogs;
                return View(model);
            }

            if (_userManager.IsInRoleAsync(user, "secretary").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;
                ViewBag.blogs = blogs;
                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "dentist").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;
                ViewBag.blogs = blogs;
                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "admin").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;
                ViewBag.blogs = blogs;
                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                return View(model);
            }


            return View();

        }
        public IActionResult BlogContent(int id)
        {
            var models = _userManager.Users.Where(i => i.IsDentist! && i.IsSecretary!);
            AppUser user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            var doctors = _context.Users.Where(i => i.IsDentist).ToList();
            var comments = _context.Comments.Where(i => i.Confirm).ToList();
            var blogs = _context.Blogs.ToList();           
            var blog=_context.Blogs.Where(i=>i.Id== id).FirstOrDefault();

           
            if (!User.Identity.IsAuthenticated)
            {
                ViewBag.blog = blog;
                ViewBag.doctors = doctors;
                ViewBag.blogs = blogs;
                ViewBag.comments = comments;
                return View();
            }
            if (_userManager.IsInRoleAsync(user, "patient").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);

                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,

                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.blog = blog;
                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                ViewBag.blogs = blogs;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "secretary").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.blog = blog;
                ViewBag.doctors = doctors;
                ViewBag.blogs = blogs;
                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "dentist").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.blog = blog;
                ViewBag.doctors = doctors;
                ViewBag.blogs = blogs;
                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "admin").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.blog = blog;
                ViewBag.doctors = doctors;
                ViewBag.blogs = blogs;
                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                return View(model);
            }


            return View();

        }
        public IActionResult Doctors()
        {

            var models = _userManager.Users.Where(i => i.IsDentist! && i.IsSecretary!);
            AppUser user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            var doctors = _context.Users.Where(i => i.IsDentist).ToList();
            var comments = _context.Comments.Where(i => i.Confirm).ToList();

            if (!User.Identity.IsAuthenticated)
            {

                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View();
            }
            if (_userManager.IsInRoleAsync(user, "patient").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);

                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,

                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };

                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                return View(model);
            }

            if (_userManager.IsInRoleAsync(user, "secretary").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "dentist").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.comments = comments;
                return View(model);
            }
            if (_userManager.IsInRoleAsync(user, "admin").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryViewModel model = new SecretaryViewModel()
                {

                    NewAppointment = _context.Appointments.Where(i => i.Tc == user.Tc).ToList(),
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList(),

                };
                ViewBag.doctors = doctors;

                ViewBag.doctors = doctors;
                ViewBag.comments = comments;
                return View(model);
            }


            return View();
        }
    }
}

