using Cellenza.Demo.SignalR.WebServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cellenza.Demo.SignalR.WebServer.Controllers
{
    public class MessagesController : Controller
    {
        public ICollection<Message> MessagesStore { get; set; }

        public MessagesController()
        {
            MessagesStore = MessagesRepository.Instance;
        }

        public MessagesController(ICollection<Message> store)
        {
            MessagesStore = store;
        }

        //
        // GET: /Chat/

        public ActionResult Index()
        {
            return View(MessagesStore);
        }

        public ActionResult Create()
        {
            return PartialView("_Create", new Message());
        }

        [HttpPost]
        public ActionResult Create(Message message)
        {
            MessagesStore.Add(message);
            if (Request.IsAjaxRequest())
            {
                return Json(message);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}
