using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcCvProject.Models.Entity;

namespace MvcCvProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            DbCvEntities db = new DbCvEntities();
            var loginData = db.Admin.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if(loginData != null)
            {
                FormsAuthentication.SetAuthCookie(loginData.UserName, false);
                Session["UserName"] = loginData.UserName.ToString();
                return RedirectToAction("Index","About");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}