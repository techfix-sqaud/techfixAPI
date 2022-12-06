using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace techfix.Models
{
    public class ContactUs
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool signature { get; set; }
    }
}