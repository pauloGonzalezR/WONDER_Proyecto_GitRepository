using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WONDER_Proyecto.Models;
using System.Collections.Immutable;

namespace WONDER_Proyecto.Controllers
{
    public class ClienteController : Controller
    {
        private readonly WONDER_ProyectoContext _context;

        public ClienteController(WONDER_ProyectoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Cliente.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Cliente.Add(cliente);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(cliente);

            }
            catch (Exception ex)
            {
                return View(cliente);
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
            var cliente = await _context.Cliente.FindAsync(ID);
            if (cliente == null)
            {
                ViewData["TipoError"] = 2;
                return View();
            }
            if (cliente.NOMBRE ==null)
            {
                ViewData["TipoError"] = 3;
                return View();
            }
            if (cliente.APELLIDO_PATERNO == null)
            {
                ViewData["TipoError"] = 4;
                return View();
            }
            if (cliente.APELLIDO_MATERNO == null)
            {
                ViewData["TipoError"] = 5;
                return View();
            }
            return View(cliente);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Cliente.Update(cliente);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(cliente);
            }
            catch
            {
                return View(cliente);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int? ID)
        {
            var cliente1 = await _context.Cliente.FindAsync(ID);
            try
            {
                var cliente = await _context.Cliente.FindAsync(ID);
                if (cliente == null)
                {
                    ViewData["TipoError"] = 6;
                    return View();
                }
                if (ModelState.IsValid)
                {
                    _context.Cliente.Remove(cliente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(cliente);
                }
            }
            catch
            {
                return View(cliente1);
            }
        }
    }
}
