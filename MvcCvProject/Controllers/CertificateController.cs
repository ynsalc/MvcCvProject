using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Models.Entity;
using MvcCvProject.Repositories;

namespace MvcCvProject.Controllers
{
    public class CertificateController : Controller
    {
        GenericRepository<Certificate> repo = new GenericRepository<Certificate>();
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var data = repo.List();
            return View(data);
        }
        [HttpGet]
        public ActionResult GetCertificate(int id)
        {
            var certificate = repo.Find(x => x.ID == id);
            return View(certificate);
        }

        [HttpPost]
        public ActionResult GetCertificate(Certificate c)
        {
            var certificate = repo.Find(x => x.ID == c.ID);
            certificate.Description = c.Description;
            certificate.Tarih = c.Tarih;
            repo.Update(certificate);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCertificate(Certificate certificate)
        {
            repo.Add(certificate);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCertificate(int id)
        {
            var selectedItem = repo.Find(x => x.ID == id);
            repo.Delete(selectedItem);
            return RedirectToAction("Index");
        }
    }
}