using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Models.Entity;
using MvcCvProject.Repositories;

namespace MvcCvProject.Controllers
{
    public class AboutController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        GenericRepository<About> repo = new GenericRepository<About>();
        // GET: About
        [HttpGet]
        public ActionResult Index()
        {
            var data = repo.List();
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(About a)
        {
            var data = repo.Find(x => x.ID == 1);
            data.FirstName = a.FirstName;
            data.LastName = a.LastName;
            data.Mail = a.Mail;
            data.Adress = a.Adress;
            data.Description = a.Description;
            data.PhoneNumber = a.PhoneNumber;
            data.Picture = a.Picture;
            repo.Update(data);
            return RedirectToAction("Index");
        }
    }
}