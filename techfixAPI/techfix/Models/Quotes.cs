using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace techfix.Models
{
    public class Quotes
    {
        public int id {get; set;}
        public string FullName {get; set;} 
        public string Email {get; set;}
        public string subject {get; set;}
        public string Description {get; set;}
        public bool signature {get; set;}
    }
}