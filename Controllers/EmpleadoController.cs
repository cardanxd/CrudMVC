using CrudMVC.Context;
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

    }
}
