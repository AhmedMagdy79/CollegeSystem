using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Models.DB
{
    public class Admin 
    {
        public User User;
        public string UserId { get; set; }
    }
}
