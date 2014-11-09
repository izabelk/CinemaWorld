using CinemaWorld.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaWorld.Web.Controllers
{
    public class PremieresController : BaseController
    {
        public PremieresController(ICinemaWorldData data)
            : base(data)
        {
        }

        // GET: Premieres
        public ActionResult Index()
        {
            return View();
        }
    }
}