using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DentistCalendar.Data;
using DentistCalendar.Data.Entity;
using DentistCalendar.Migrations;
using DentistCalendar.Models;
using Iyzipay.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Iyzipay;
using Iyzipay.Model;
using Microsoft.AspNetCore.Identity;

namespace DentistCalendar.Controllers
{
    public class AppointmentController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<AppUser> _user;
        public AppointmentController(ApplicationDbContext context, UserManager<AppUser> user)
        {
            _context = context;
            _user = user;
        }

        public JsonResult GetAppointments()
        {
            var model = _context.Appointments
                .Include(x => x.User).Select(x => new AppointmentViewModel()
                {
                    TC = x.Tc,
                    Id = x.Id,
                    Dentist = x.User.Name + " " + x.User.Surname,
                    PatientName = x.PatientName,
                    PatientSurname = x.PatientSurname,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Description = x.Description,
                    Color = x.User.Color,
                    UserId = x.User.Id,
                    Paid = x.Paid,
                   PhoneNumber= x.PhoneNumber

                });

            return Json(model);
        }

        public JsonResult GetAppointmentsByDentist(string userId = "")
        {
            var model = _context.Appointments.Where(x => x.UserId == userId)
                .Include(x => x.User).Select(x => new AppointmentViewModel()
                {
                    TC = x.Tc,
                    Id = x.Id,
                    Dentist = x.User.Name + " " + x.User.Surname,
                    PatientName = x.PatientName,
                    PatientSurname = x.PatientSurname,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Description = x.Description,
                    Color = x.User.Color,
                    UserId = x.User.Id,
                    PhoneNumber=x.PhoneNumber
                  
                });
           
            return Json(model);
        }

        [HttpPost]
        public IActionResult AddOrUpdateAppointment(SecretaryViewModel model)
        {
            var appointment = _context.Appointments.Where(i => i.UserId == model.UserId).Select(a => a.StartDate).ToList();

            if (appointment.Count == 0)
            {
                var doctor = _context.Users.Where(i => i.Id == model.UserId).Select(x => x.Name + " " + x.Surname).FirstOrDefault();

                Appointment entity = new Appointment()
                {
                    CreatedDate = DateTime.Now,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    PatientName = model.PatientName,
                    PatientSurname = model.PatientSurname,
                    Description = "Ödenmedi",
                    UserId = model.UserId,
                    Tc = model.Tc,
                    DoctorName = doctor,
                    OnlinePaid = true,
                    Paid = false,
                    Price = (model.EndDate.Hour - model.StartDate.Hour) * 250,
                    PhoneNumber=model.PhoneNumber
                };


                if (model.StartDate.DayOfYear - DateTime.Now.DayOfYear <= 14)
                {
                    _context.Appointments.Add(entity);
                    _context.SaveChanges();

                    TempData["messages"] = $"Randevunuz Başarıyla Oluşturuldu!";
                    return Redirect("/user/index#booking");
                }
                else
                {
                    TempData["message"] = $"Randevu en fazla 14 gün sonrasına verilir";
                    return Redirect("/user/index#booking");
                }

            }

            else
            {
                foreach (var item in appointment)
                {
                    if (model.StartDate == item)
                    {
                        return View("Catch");
                    }
                    else
                    {
                        var doctor = _context.Users.Where(i => i.Id == model.UserId).Select(x => x.Name + " " + x.Surname).FirstOrDefault();

                        Appointment entity = new Appointment()
                        {
                            CreatedDate = DateTime.Now,
                            StartDate = model.StartDate,
                            EndDate = model.EndDate,
                            PatientName = model.PatientName,
                            PatientSurname = model.PatientSurname,
                            Description = "Ödenmedi",
                            UserId = model.UserId,
                            Tc = model.Tc,
                            DoctorName = doctor,
                            Price = (model.EndDate.Hour - model.StartDate.Hour) * 250,
                            PhoneNumber= model.PhoneNumber



                        };

                        if (model.StartDate.DayOfYear - DateTime.Now.DayOfYear <= 14)
                        {
                            _context.Appointments.Add(entity);
                            _context.SaveChanges();

                            TempData["messages"] = $"Randevunuz Başarıyla Oluşturuldu!";
                            return Redirect("/user/randevudetay");
                        }
                        else
                        {
                            TempData["message"] = $"Randevu en fazla 14 gün sonrasına verilir";
                            return Redirect("/user/randevudetay");


                        }

                    }
                }



                return View(model);
            }

        }
            [HttpPost]
            public JsonResult AddOrUpdateAppointmentS(AddOrUpdateAppointmentModel model)
            {
            var doctor = _context.Users.Where(i => i.Id == model.UserId).Select(x => x.Name + " " + x.Surname).FirstOrDefault();

            //Validasyon
            if (model.Id == 0)
                {
                    Appointment entity = new Appointment()
                    {
                        CreatedDate = DateTime.Now,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate,
                        PatientName = model.PatientName,
                        PatientSurname = model.PatientSurname,
                        Description = model.Description,
                        UserId = model.UserId,
                        Tc = model.TC,
                        DoctorName=doctor,
                        PhoneNumber=model.PhoneNumber
                    };

                    _context.Add(entity);
                    _context.SaveChanges();
                }
                else
                {

                    var entity = _context.Appointments.SingleOrDefault(x => x.Id == model.Id);
                    if (entity == null)
                    {
                        return Json("Güncellenecek veri bulunamadı.");
                    }
                    entity.UpdatedDate = DateTime.Now;
                    entity.PatientName = model.PatientName;
                    entity.PatientSurname = model.PatientSurname;
                    entity.Description = model.Description;
                    entity.StartDate = model.StartDate;
                    entity.EndDate = model.EndDate;
                    entity.UserId = model.UserId;
                    entity.Tc = model.TC;
                entity.PhoneNumber= model.PhoneNumber;
                entity.DoctorName = doctor;
                    _context.Update(entity);
                    _context.SaveChanges();
                }

                return Json("200");
            }

         

            public JsonResult DeleteAppointment(int id = 0)
            {
                var entity = _context.Appointments.SingleOrDefault(x => x.Id == id);
                if (entity == null)
                {
                    return Json("Kayıt bulunamadı.");
                }
                _context.Remove(entity);
                _context.SaveChanges();
                return Json("200");
            }
        }
    } 