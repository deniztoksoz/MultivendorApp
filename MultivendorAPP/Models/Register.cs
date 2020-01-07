using System;
using System.Collections.Generic;
using System.Text;

namespace MultivendorAPP.Models
{
    public class Register
    {
       
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Facebook { get; set; }
        public string StripeKey { get; set; }
        public string Level { get; set; }
        public int MasterId { get; set; }
        public int StokisId { get; set; }

    }
}
