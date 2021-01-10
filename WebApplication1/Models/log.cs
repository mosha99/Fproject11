using ClassLibrary1.database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class log
    {
        
        public string _UserName { set; get; }
        public string _UserName_error { set; get; }
        [DataType(DataType.Password)]
        public string _password { set; get; }
        public string _password_error { set; get; }
        public string url { set; get; }
        public bool accepted { set; get; }
        public User loge { set; get; }
       

    }
}