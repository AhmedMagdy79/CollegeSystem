using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Models.Response
{
    public class LogInResponse
    {
        public string Email { get; set; }

        public string AccessToken { get; set; }
    }
}
