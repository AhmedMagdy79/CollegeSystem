using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Models
{
    public class ServiceResult<T>
    {
        public int StatusCode { get; set; }

        public T? Result { get; set; }
    }
}
