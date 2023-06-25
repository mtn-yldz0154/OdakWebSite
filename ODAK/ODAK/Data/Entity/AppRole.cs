using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistCalendar.Data.Entity
{
    public class AppRole : IdentityRole
    {
        public AppRole()
        {

        }
        public AppRole(string roleName) : base(roleName)
        {
        }
    }
}
