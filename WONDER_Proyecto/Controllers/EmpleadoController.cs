using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WONDER_Proyecto.Models;
using System.Collections.Immutable;

namespace WONDER_Proyecto.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly WONDER_ProyectoContext _context;

        public EmpleadoController(WONDER_ProyectoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Empleado.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Empleado empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Empleado.Add(empleado);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(empleado);

            }
            catch (Exception ex)
            {
                return View(empleado);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Editar(int? ID)
        {
            if (ID == null)
            {
                ViewData["TipoError"] = 1;
                return View();
            }
            var empleado = await _context.Empleado.FindAsync(ID);
            if (empleado == null)
            {
                ViewData["TipoError"] = 2;
                return View();
            }
            if (empleado.NOMBRE == null)
            {
                ViewData["TipoError"] = 3;
                return View();
            }
            if (empleado.APELLIDO_PATERNO == null)
            {
                ViewData["TipoError"] = 4;
                return View();
            }
            if (empleado.APELLIDO_MATERNO == null)
            {
                ViewData["TipoError"] = 5;
                return View();
            }
            return View(empleado);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Empleado empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Empleado.Update(empleado);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(empleado);
            }
            catch
            {
                return View(empleado);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int? ID)
        {
            var empleado1 = await _context.Empleado.FindAsync(ID);
            try
            {
                var empleado = await _context.Empleado.FindAsync(ID);
                if (empleado == null)
                {
                    ViewData["TipoError"] = 6;
                    return View();
                }
                if (ModelState.IsValid)
                {
                    _context.Empleado.Remove(empleado);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(empleado);
                }
            }
            catch
            {
                return View(empleado1);
            }
        }
    }
}
