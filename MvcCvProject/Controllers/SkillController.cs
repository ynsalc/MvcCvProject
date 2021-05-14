using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Models.Entity;
using MvcCvProject.Repositories;

namespace MvcCvProject.Controllers
{
    public class SkillController : Controller
    {
        GenericRepository<Skills> repo = new GenericRepository<Skills>();
        // GET: Skill
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(Skills s)
        {
            repo.Add(s);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var skill = repo.Find(x => x.ID == id);
            repo.Delete(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var skill = repo.Find(x => x.ID == id);
            return View(skill);
        }

        [HttpPost]
        public ActionResult UpdateSkill(Skills s)
        {
            Skills u = repo.Find(x => x.ID == s.ID);
            u.ID = s.ID;
            u.Skill = s.Skill;
            u.SkillInfo = s.SkillInfo;
            repo.Update(u);
            return RedirectToAction("Index");
        }
    }
}