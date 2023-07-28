using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WONDER_Proyecto.Models;
using System.Collections.Immutable;

namespace WONDER_Proyecto.Controllers
{
    public class TipoUsuarioController : Controller
    {
        private readonly WONDER_ProyectoContext _context;

        public TipoUsuarioController(WONDER_ProyectoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoUsuario.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(TipoUsuario tipoUsuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.TipoUsuario.Add(tipoUsuario);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(tipoUsuario);

            }
            catch (Exception ex)
            {
                return View(tipoUsuario);
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
            var tipoUsuario = await _context.TipoUsuario.FindAsync(ID);
            if (tipoUsuario == null)
            {
                ViewData["TipoError"] = 2;
                return View();
            }
            if (tipoUsuario.DESCRIPCION == null)
            {
                ViewData["TipoError"] = 3;
                return View();
            }
            return View(tipoUsuario);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(TipoUsuario tipoUsuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.TipoUsuario.Update(tipoUsuario);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(tipoUsuario);
            }
            catch
            {
                return View(tipoUsuario);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int? ID)
        {
            var tipoUsuario1 = await _context.TipoUsuario.FindAsync(ID);
            try
            {
                var tipoUsuario = await _context.TipoUsuario.FindAsync(ID);
                if (tipoUsuario == null)
                {
                    ViewData["TipoError"] = 6;
                    return View();
                }
                if (ModelState.IsValid)
                {
                    _context.TipoUsuario.Remove(tipoUsuario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(tipoUsuario);
                }
            }
            catch
            {
                return View(tipoUsuario1);
            }
        }
    }
}
