﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Models.DB
{
    public class User : IdentityUser
    {
        public ICollection<UserToken> UserToken { get; set; }
    }
}
