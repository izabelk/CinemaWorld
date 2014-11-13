namespace CinemaWorld.Web.Areas.Administration.Controllers.Base
{
    using System.Web.Mvc;

    using CinemaWorld.Data.UnitOfWork;
    using CinemaWorld.Web.Controllers;

    [Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        public AdminController(ICinemaWorldData data)
            : base(data)
        {
        }
    }
}