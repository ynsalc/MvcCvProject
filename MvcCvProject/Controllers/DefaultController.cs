using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Models.Entity;

namespace MvcCvProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var deger = db.About.ToList();
            return View(deger);
        }
        public PartialViewResult Deneyim()
        {
            var deneyim = db.Experience.ToList();
            return PartialView(deneyim);
        }

        public PartialViewResult Education()
        {
            var education = db.Education.ToList();
            return PartialView(education);
        }

        public PartialViewResult Skill()
        {
            var skill = db.Skills.ToList();
            return PartialView(skill);
        }

        public PartialViewResult Interests()
        {
            var interest = db.Interests.ToList();
            return PartialView(interest);
        }

        public PartialViewResult Certificate()
        {
            var certificate = db.Certificate.ToList();
            return PartialView(certificate);
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(Contact contact)
        {
            contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Contact.Add(contact);
            db.SaveChanges();
            return PartialView();
        }
    }
}