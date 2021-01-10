using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class recoveryPassword
    {
        public string email { set; get; }
        public string email_error { set; get; }
        public string code { set; get; }
        public string code_error { set; get; }
        public string newpassword { set; get; }
        public string newpassword_error { set; get; }

    }
}