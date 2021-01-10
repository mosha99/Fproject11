using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.database
{
    public class mycontext:DbContext
    {
        public mycontext() : base("user-data") { }
        public DbSet<User> users { set; get; }

    }
}
