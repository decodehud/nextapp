using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nextapp.Context;
using nextapp.Models;

namespace nextapp.Controllers
{
    [Authorize(Roles = "administrador, invitado")]
    public class PortalController : Microsoft.AspNetCore.Mvc.Controller
    {
        // GET: PortalController
        readonly MantenimientoSolicitud dbContext = new MantenimientoSolicitud();
  
        public Microsoft.AspNetCore.Mvc.ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public Microsoft.AspNetCore.Mvc.ActionResult Create([Bind] Solicitud solicitud)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.CreateSolicitud(solicitud);
                   return Redirect("/Home/Index");
                }
                return View(solicitud);
            }
            catch
            {
                return View();
            }
        }

    }
}
