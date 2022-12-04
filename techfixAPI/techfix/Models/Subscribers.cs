using System.Runtime.Serialization;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace techfix.Models
{
    public class Subscribers
    { 
        public int id { get; set; }
        public string Email { get; set; }
        public DateTime? joinDate { get; set;} = DateTime.UtcNow.Date;
    }
}