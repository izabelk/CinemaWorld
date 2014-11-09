﻿namespace CinemaWorld.Web.Controllers
{
    using System.Web.Mvc;

    using CinemaWorld.Data.UnitOfWork;

    public class BaseController : Controller
    {
        protected ICinemaWorldData Data;

        public BaseController(ICinemaWorldData data)
        {
            this.Data = data;
        }
    }
}