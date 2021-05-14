using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Models.Entity;
using MvcCvProject.Repositories;

namespace MvcCvProject.Controllers
{
    public class InterestsController : Controller
    {
        GenericRepository<Interests> repo = new GenericRepository<Interests>();
        // GET: Interests
        [HttpGet]
        public ActionResult Index()
        {
            var data = repo.List();
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(Interests interest)
        {
            Interests i = repo.Find(x => x.ID == 1);
            i.Description = interest.Description;
            i.Description2 = interest.Description2;
            repo.Update(i);
            return RedirectToAction("Index");
        }
    }
}