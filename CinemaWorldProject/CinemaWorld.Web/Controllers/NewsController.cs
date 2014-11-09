using CinemaWorld.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaWorld.Web.Controllers
{
    public class NewsController : BaseController
    {
        public NewsController(ICinemaWorldData data)
            : base(data)
        {
        }

        // GET: News
        public ActionResult Index()
        {
            return View();
        }
    }
}