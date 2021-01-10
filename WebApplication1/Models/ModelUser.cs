using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ModelUser
    {
        
        public string ferstname_error { set; get; }
        public string ferstname { set; get; }
        public string LastName_error { set; get; }
        public string LastName { set; get; }
        public string UserName_error { set; get; }
        public string UserName_Duplicate { set; get; }
        public string UserName { set; get; }
        public string password_error { set; get; }
        [DataType(DataType.Password)]
        public string password { set; get; }
        public string email_error { set; get; }
        public string email_Duplicate { set; get; }
        public string email { set; get; }
        public bool accepted { set; get; }

    } 
}