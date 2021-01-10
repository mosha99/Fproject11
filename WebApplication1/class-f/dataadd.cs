using ClassLibrary1.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.class_f
{
    public class dataadd : Idata
    {
        public ModelUser add(ModelUser model)
        {
            if (model.ferstname_error == null & model.LastName_error == null & model.UserName_error == null & model.email_error == null & model.password_error == null)
            {

                var data = new mycontext();

                var Usercheck = data.users.FirstOrDefault(m => m.UserName == model.UserName);
                var Emailcheck = data.users.FirstOrDefault(m => m.email == model.email);

                if (Emailcheck != null | Usercheck != null)
                {
                    if (Emailcheck != null) model.email_Duplicate = "از قبل حسابی با این ایمیل ثبت شده است";
                    if (Usercheck != null) model.UserName_Duplicate = "نام کاربری تکراری است";
                    return model;
                }
                else
                {
                    data.users.Add(new User
                    {
                        ferstname = (model.ferstname),
                        LastName = (model.LastName),
                        email = (model.email),
                        UserName = (model.UserName),
                        Password = (model.password)
                    });
                    data.SaveChanges();
                    model.accepted = true;
                    return model;

                }

            }
            else
                model.accepted = false;
                return model;
        }

        public int addd(int a, int b)
        {
            return a + b;
        }
    }
}