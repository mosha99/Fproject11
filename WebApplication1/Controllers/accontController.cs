using ClassLibrary1.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebApplication1.class_f;
using WebApplication1.Models;
using System.Web.Security;


namespace WebApplication1.Controllers
{
    public class accontController : Controller
    {
        Idata Add = new dataadd();
        Ifilter filter = new signfilter();
        signfilter lFilter = new signfilter();
        logfilter DFilter = new login();

        // GET: accont
        public ActionResult signin()
        {


            ModelUser model = new ModelUser();

            return View(model);
        }

        [HttpPost]
        public ActionResult signin(ModelUser model)
        {
            model = filter.Cheker(model);
            model = Add.add(model);

            if (!model.accepted | model.email_Duplicate != null | model.UserName_Duplicate != null) return View(model);
            else
            {
                log logmodel = new log();
                logmodel._UserName = model.UserName;
                logmodel._password = null;
                return View("login", logmodel);
            }

        }

        public ActionResult login()
        {
            log model = new log();
            if(Request.QueryString["ReturnUrl"] != null)model.url = Request.QueryString["ReturnUrl"].ToString();
                                                 else   model.url = Url.Action("Index","Home",null);

            return View(model);
        }
        [HttpPost]
        public ActionResult login(log model)
        {
            bool Access;
            model = DFilter.Inspection(model);
            Access = model.accepted;



            if (!Access)
            {

                model._password = null;
                return View(model);
            }

            else
            {
                welcom Wmodel = new welcom();

                FormsAuthentication.SetAuthCookie(model._UserName, false);
                HttpCookie cook = new HttpCookie("userName", model._UserName);
                Response.Cookies.Add(cook);
                //cook.Expires = DateTime.Now.AddHours(24);
                if (model.url != null) return Redirect(model.url); else return Redirect(Url.Action("Index", "Home", null));
            }


        }
        [Authorize]
        public ActionResult welcom()
        {
            string user = Request.Cookies["userName"].Value.ToString();
            mycontext data = new mycontext();
            var _user = data.users.FirstOrDefault(m => m.UserName == user);
            welcom Wmodel = new welcom();
            Wmodel.fullName = _user.ferstname + " " + _user.LastName;
            return View(Wmodel);
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect(Url.Action("login"));
            
            Response.Cookies["userName"].Expires = DateTime.Now.AddDays(-1);

        }
        public ActionResult lostPassword()
        {
            recoveryPassword model = new recoveryPassword();
            return View(model);
        }
        [HttpPost]
        public ActionResult lostPassword(recoveryPassword model)
        {
            mycontext check = new mycontext();
            ModelUser ch = new ModelUser();
            var Echeck = check.users.FirstOrDefault(m => m.email == model.email);
            if (model.email != null)
            {
                
                if (Echeck == null) model.email_error = "کاربری با این ایمیل در سامانه وجود ندارد";
                else model.email_error = null;
            }
            else model.email_error = "لطفا ایمیل خود را وارد نمایید";



            if (model.code == null) model.code_error = "(پوشه اسپم را نیز چک نمایید)" + "لطفا کد ارسال شده به ایمیل خود را وارد نمایید";
            else if (model.code != "123456") model.code_error = "کد وارد شده نامعتبر است";
            else model.code_error = null;

            if (model.newpassword != null)
            {
               
                ch.password = model.newpassword;
                ch=filter.Cheker(ch);
                model.newpassword_error=ch.password_error;
            }
            else model.newpassword_error = "لطفا یک گذر واژه انتخاب نمایید";
            if (model.newpassword_error == null & model.code_error == null & model.email_error==null)
            {
                log relog = new log();
                Echeck.Password = model.newpassword;
                check.SaveChanges();
                relog._UserName = Echeck.UserName;
                relog._password = model.newpassword;
                relog.url = Url.Action("index", "home");
                return View("login",relog);
                
            }
            
            
                return View(model);
        }
    }
}