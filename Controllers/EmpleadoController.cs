using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nextapp.Context;
using nextapp.Models;
using System.Collections.Generic;
using System.Linq;

namespace nextapp.Controllers
{
    [Authorize(Roles = "administrador")]
    public class EmpleadoController : Microsoft.AspNetCore.Mvc.Controller
    {

        readonly MantenimientoEmpleado dbContext = new MantenimientoEmpleado();
        // GET: EmpleadoController
        public Microsoft.AspNetCore.Mvc.ActionResult Index()
        {
            List<Empleado> empleadoList = dbContext.GetAllEmpleado().ToList();

            return View(empleadoList);
        }

        // GET: EmpleadoController/Details/5
        public Microsoft.AspNetCore.Mvc.ActionResult Details(int id_empleados)
        {

            if (id_empleados <= 0)
            {
                return NotFound();
            }

            Empleado empleado = dbContext.GetEmpleadoById(id_empleados);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // GET: EmpleadoController/Create
        
        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Microsoft.AspNetCore.Mvc.ActionResult Create([Bind] Empleado empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.CreateEmpleado(empleado);
                   return RedirectToAction("Index");
                }
                return View(empleado);
            }
            catch
            {
                return View();
            }
        }


        // GET: EmpleadoController/Edit/5
        public Microsoft.AspNetCore.Mvc.ActionResult Edit(int id_empleados)
        {

            if (id_empleados <= 0)
            {
                return NotFound();
            }
            Empleado empleado = dbContext.GetEmpleadoById(id_empleados);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Microsoft.AspNetCore.Mvc.ActionResult Edit(int id_empleados, [Bind] Empleado empleado)
        {
            try
            {

                if (id_empleados <= 0)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    dbContext.UpdateEmpleado(empleado);
                    return RedirectToAction("Index");

                }
                return View(dbContext);
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController//5
        public Microsoft.AspNetCore.Mvc.ActionResult Delete(int id_empleados)
        {
            if (id_empleados <= 0)
            {
                return NotFound();
            }
            Empleado empleado = dbContext.GetEmpleadoById(id_empleados);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public Microsoft.AspNetCore.Mvc.ActionResult DeleteConfirm(int? id_empleados)
        {
            try
            {
                dbContext.DeleteEmpleado(id_empleados);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
