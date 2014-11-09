using CinemaWorld.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaWorld.Web.Controllers
{
    public class ProgramController : BaseController
    {
        public ProgramController(ICinemaWorldData data)
            : base(data)
        {
        }

        // GET: Program
        public ActionResult Index()
        {
            return View();
        }
    }
}