using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvProject.Models.Entity;
using MvcCvProject.Repositories;

namespace MvcCvProject.Controllers
{
    public class ContactController : Controller
    {
        GenericRepository<Contact> repo = new GenericRepository<Contact>();
        // GET: Contact
        public ActionResult Index()
        {
            var data = repo.List();
            return View(data);
        }
    }
}