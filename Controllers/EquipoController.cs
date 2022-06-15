using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nextapp.Context;
using nextapp.Models;
using System.Collections.Generic;
using System.Linq;

namespace nextapp.Controllers
{
    [Authorize(Roles = "administrador")]
    public class EquipoController : Microsoft.AspNetCore.Mvc.Controller
    {
        readonly MantenimientoEquipo dbContext = new MantenimientoEquipo();
        // GET: EquipoController
        public Microsoft.AspNetCore.Mvc.ActionResult Index()
        {
            List<Equipo> equipoList = dbContext.GetAllEquipo().ToList();
            return View(equipoList);

        }

        // GET: EquipoController/Details/5
        public Microsoft.AspNetCore.Mvc.ActionResult Details(int id_equipo)
        {
            if (id_equipo <= 0)
            {
                return NotFound();
            }

            Equipo equipo = dbContext.GetEquipoById(id_equipo);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        // GET: EquipoController/Create
        public Microsoft.AspNetCore.Mvc.ActionResult Create()
        {

            return View();
        }

        // POST: EquipoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Microsoft.AspNetCore.Mvc.ActionResult Create([Bind] Equipo equipo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.CreateEquipo(equipo);
                    return RedirectToAction("Index");
                }
                return View(equipo);
            }
            catch
            {
                return View();
            }
        }

        // GET: EquipoController/Edit/5
        public Microsoft.AspNetCore.Mvc.ActionResult Edit(int id_equipos)
        {
            if (id_equipos <= 0)
            {
                return NotFound();
            }
            Equipo equipo = dbContext.GetEquipoById(id_equipos);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        // POST: EquipoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Microsoft.AspNetCore.Mvc.ActionResult Edit(int id_equipos, [Bind] Equipo equipo)
        {
            try
            {

                if (id_equipos <= 0)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    dbContext.UpdateEquipo(equipo);
                    return RedirectToAction("Index");

                }
                return View(dbContext);
            }
            catch
            {
                return View();
            }
        }

        // GET: EquipoController/Delete/5
        public Microsoft.AspNetCore.Mvc.ActionResult Delete(int id_equipos)
        {
            if (id_equipos <= 0)
            {
                return NotFound();
            }
            Equipo equipo = dbContext.GetEquipoById(id_equipos);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        // POST: EquipoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public Microsoft.AspNetCore.Mvc.ActionResult DeleteConfirm(int? id_equipos)
        {
            try
            {
                dbContext.DeleteEquipo(id_equipos);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
