using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Models.Entity;
using MvcCvProject.Repositories;

namespace MvcCvProject.Controllers
{
    public class EducationController : Controller
    {
        EducationRepository repository = new EducationRepository();
        public ActionResult Index()
        {
            var degerler = repository.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEducation(Education education)
        {
            repository.Add(education);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            Education education = repository.Find(x => x.ID == id);
            repository.Delete(education);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            Education e = repository.Find(c => c.ID == id);
            return View(e);
        }

        [HttpPost]
        public ActionResult UpdateEducation(Education e)
        {
            Education ed = repository.Find(c => c.ID == e.ID);
            ed.Title = e.Title;
            ed.SubTitle1 = e.SubTitle1;
            ed.SubTitle2 = e.SubTitle2;
            ed.GNO = e.GNO;
            repository.Update(ed);
            return RedirectToAction("Index");
        }
    }
}