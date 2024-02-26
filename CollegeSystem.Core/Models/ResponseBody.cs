using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSystem.Core.Models
{
    public class ResponseBody<T>
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public T? Result { get; set; }
    }
}
