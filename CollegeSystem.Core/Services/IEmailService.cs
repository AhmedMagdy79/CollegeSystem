﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Services
{
    public interface IEmailService
    {
        Task SendVerificationTokenAsync(string email, string token, string userId);
    }
}
