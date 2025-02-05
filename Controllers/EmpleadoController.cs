using CrudMVC.Context;
using CrudMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudMVC.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly AppDBContext _context;
        public EmpleadoController(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Lista()
        {
            var lista = await _context.Empleados.ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                await _context.Empleados.AddAsync(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Lista));
            }
            return View(empleado);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            return View(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Empleados.Update(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Lista));
            }
            return View(empleado);
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Empleado empleado = await _context.Empleados.FirstAsync(x => x.IdEmpleado == id);
            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
