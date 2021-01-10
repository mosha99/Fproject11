using ClassLibrary1.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.class_f
{
    public class login:logfilter
    {
        public log Inspection(log model)
        {
            bool Access;
            var data = new mycontext();
            string user = model._UserName;

            if (user == null)
            {
                model._UserName_error = "نام کاربری خود را وارد نمایید";

                Access = false;


            }
            else
                Access = true;


            var logUser = data.users.FirstOrDefault(m => m.UserName == user);

            if (logUser != null)
            {
                if (model._password != logUser.Password)
                {
                    model._password_error = "نام کاربری یا کلمه عبور اشتباه است";
                    Access = false;
                }
                else
                {
                    Access = true;
                }
            }
            else
            {
                model._password_error = "نام کاربری یا کلمه عبور اشتباه است";
                Access = false;
            }
            model.accepted = Access;
            model.loge = logUser;
            return model;
        }
    }
}