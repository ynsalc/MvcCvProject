using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Models.Entity;
using MvcCvProject.Repositories;

namespace MvcCvProject.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceRepository repository = new ExperienceRepository();
        public ActionResult Index()
        {
            var degerler = repository.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(Experience experience)
        {
            repository.Add(experience);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            Experience experience = repository.Find(x => x.ID == id);
            repository.Delete(experience);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            Experience experience = repository.Find(x => x.ID == id);
            return View(experience);
        }

        [HttpPost]
        public ActionResult GetExperience(Experience e)
        {
            Experience experience = repository.Find(x => x.ID == e.ID);
            experience.Title = e.Title;
            experience.SubTitle = e.SubTitle;
            experience.Date = e.Date;
            experience.Description = e.Description;
            repository.Update(experience);
            return RedirectToAction("Index");
        }
    }
}