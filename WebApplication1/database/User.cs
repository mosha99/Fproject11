using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.database
{
    public class User
    {
        public int id  { set; get; }
        [MaxLength(30)]
        public string UserName { set; get; }
        [MaxLength(30)]
        public string ferstname { set; get; }
        [MaxLength(30)]
        public string LastName { set; get; }
        [MaxLength(30)]
        public string email { set; get; }

        [ MaxLength(30)]
        public string Password { set; get; }
        
    }
}
