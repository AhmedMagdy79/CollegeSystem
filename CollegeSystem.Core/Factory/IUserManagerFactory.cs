using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Factory
{
    public interface IUserManagerFactory
    {
        object GetUserManager(string userType);
    }
}
