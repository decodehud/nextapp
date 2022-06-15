using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nextapp.Context;
using nextapp.Models;
using System.Collections.Generic;
using System.Linq;

namespace nextapp.Controllers
{
    [Authorize(Roles = "administrador")]
    public class SolicitudController : Microsoft.AspNetCore.Mvc.Controller
    {
        readonly MantenimientoSolicitud dbContext = new MantenimientoSolicitud();
        public IActionResult Index()
        {
            List<Solicitud> solicitudList = dbContext.GetAllSolicitud().ToList();
            return View(solicitudList);
        }

        //
        public Microsoft.AspNetCore.Mvc.ActionResult Create()
        {

            return View();
        }

        // POST: EquipoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Microsoft.AspNetCore.Mvc.ActionResult Create([Bind] Solicitud solicitud)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.CreateSolicitud(solicitud);
                    RedirectToAction("Index");
                }
                return View(solicitud);
            }
            catch
            {
                return View();
            }
        }

        //
        public Microsoft.AspNetCore.Mvc.ActionResult Edit(int id_Solicitud)
        {
            if (id_Solicitud <= 0)
            {
                return NotFound();
            }
            Solicitud solicitud = dbContext.GetSolicitudById(id_Solicitud);
            if (solicitud == null)
            {
                return NotFound();
            }
            return View(solicitud);
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Microsoft.AspNetCore.Mvc.ActionResult Edit(int id_solicitud, [Bind] Solicitud solicitud)
        {
            try
            {

                if (id_solicitud <= 0)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    dbContext.UpdateSolicitud(solicitud);
                    return RedirectToAction("Index");

                }
                return View(solicitud);
            }
            catch
            {
                return View();
            }
        }

        //

        public Microsoft.AspNetCore.Mvc.ActionResult Delete(int id_Solicitud)
        {
            if (id_Solicitud <= 0)
            {
                return NotFound();
            }
            Solicitud solicitud = dbContext.GetSolicitudById(id_Solicitud);
            if (solicitud == null)
            {
                return NotFound();
            }
            return View(solicitud);
        }

        // POST: EquipoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public Microsoft.AspNetCore.Mvc.ActionResult DeleteConfirm(int? id_Solicitud)
        {
            try
            {
                dbContext.DeleteEquipo(id_Solicitud);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
