using Phonebook.WebApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Phonebook.WebApp.Controllers
{
    public class PhonebookController : Controller
    {

        // GET: Phonebook
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPhonebookEntry()
        {
            return PartialView("_AddPhonebookEntry");
        }

        public ActionResult ShowPhonebookEntries()
        {
            return PartialView("_ShowPhonebookEntries");
        }

        public ActionResult ShowPhonebookEntry()
        {
            return PartialView("_ShowPhonebookEntry");
        }

        public ActionResult EditPhonebookEntry()
        {
            return PartialView("_EditPhonebookEntry");
        }

        public ActionResult DeletePhonebookEntry()
        {
            return PartialView("_DeletePhonebookEntry");
        }
    }
}