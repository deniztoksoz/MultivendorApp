using System;
using System.Collections.Generic;
using System.Text;

namespace MultivendorAPP.Models
{
   public class Users
    {
    
            public int id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
             public string Phone { get; set; }
            public string address { get; set; }
            public string facebook { get; set; }
            public string stripeKey { get; set; }
            public string level { get; set; }
            public int masterId { get; set; }
            public int stokisId { get; set; }
        
    }
}
