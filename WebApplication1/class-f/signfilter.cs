using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.class_f
{
    public class signfilter: Ifilter 
    {
        public ModelUser Cheker(ModelUser model)
        
        {

            bool nacces, facces, uacces, eacces, pacces;

            if (model.ferstname == null) model.ferstname_error = ErrorMessage(6, false);
            else
            {
                nacces = controllerfilld(model.ferstname, "^[ ا-ی]" + "{3,16}$");
                model.ferstname_error = ErrorMessage(1, nacces);
            }
            if (model.LastName == null) model.LastName_error = ErrorMessage(6, false);
            else
            {
                facces = controllerfilld(model.LastName, "^[ ا-ی]" + "{4,16}$");
                model.LastName_error = ErrorMessage(2, facces);
            }
            if (model.UserName == null) model.UserName_error = ErrorMessage(6, false);
            else
            {
                uacces = controllerfilld(model.UserName, "^[a-zA-Z0-9]{8,30}$");
                model.UserName_error = ErrorMessage(3, uacces);
            }
            if (model.email == null) model.email_error = ErrorMessage(6, false);
            else
            {
                eacces = controllerfilld(model.email, "^(([a-zA-Z0-9._%-]{3,15})+@([a-zA-Z0-9.-]{5,16})+.[a-zA-Z]{2,4})*$");
                model.email_error = ErrorMessage(4, eacces);
            }
            if (model.password == null) model.password_error = ErrorMessage(6, false);
            else
            {
                pacces = controllerfilld(model.password, "^(?=^.{6,}$)((?=.*[A-Za-z0-9])(?=.*[A-Z])(?=.*[a-z]))^.*$");
                model.password_error = ErrorMessage(5, pacces);
            }




            return (model);
        }
        private bool controllerfilld(string input, string regex)
        {
            Regex filter = new Regex(regex);
            bool acces = filter.IsMatch(input);
            return (acces);
        }

        

        private string ErrorMessage(int id, bool acces)
        {
            string errorMessage = null;

            switch (id)
            {
                case 1:
                    errorMessage = "نام باید به صورت فارسی و بیش از 2 حرف باشد";
                    break;
                case 2:
                    errorMessage = "نام خانوادگی باید به صورت فارسی و بیش از 3 حرف باشد";
                    break;
                case 3:
                    errorMessage = "نام کاربری باید به صورت انگلیسی و بیش از 4 کارکتر باشد";
                    break;
                case 4:
                    errorMessage = "ایمیل نامعتبر می باشد";
                    break;
                case 5:
                    errorMessage = "گذرواژه باید دارای حروف کوچک و بزرگ اینگلیسی و عدد و بیش از 8 کارکتر  باشد";
                    break;
                case 6:
                    errorMessage = "این فیلد اجباری است";
                    break;
                case 7:
                    errorMessage = "لطفا نام کاربری خود را خود را وارد نمایید";
                    break;
                case 8:
                    errorMessage = "نام کاربری یا ایمیل نا معتبر است";
                    break;

            }
            if (acces) errorMessage = null;
            return (errorMessage);
        }
    }
}