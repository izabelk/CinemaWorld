using CinemaWorld.Data.UnitOfWork;
using CinemaWorld.Web.Areas.Administration.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaWorld.Web.Areas.Administration.Controllers
{
    public class NewsController : AdminController
    {
        public NewsController(ICinemaWorldData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}