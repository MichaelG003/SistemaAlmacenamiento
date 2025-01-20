using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaAlmacenamiento.Models;
using SistemaAlmacenamiento.Data;
using Microsoft.EntityFrameworkCore;

namespace SistemaAlmacenamiento.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Acción para mostrar el formulario de registro
        public IActionResult Crear()
        {
            return View();
        }

        // Acción para manejar el registro de remesas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Cliente clientes)
        {
            if (ModelState.IsValid)
            {
                clientes.FechaCreacion = DateTime.UtcNow;
                _context.Clientes.Add(clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction("TablaClientes","Listado"); // Redirige a la lista de Clientes
            }
            return View(clientes); // Si hay errores, vuelve a mostrar el formulario
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}