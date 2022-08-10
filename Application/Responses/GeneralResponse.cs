using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public class GeneralResponse
    {
        public bool Status { get; set; } = false;
        public string Message { get; set; }
    }
    public class GeneralResponse<T>: GeneralResponse
    {
        public T Response { get; set; }
    }
}
