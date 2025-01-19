using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaAlmacenamiento.Data;
using SistemaAlmacenamiento.Models;

namespace SistemaAlmacenamiento.Controllers
{
    public class ListadoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Acción para mostrar la tabla de clientes
        public async Task<IActionResult> TablaClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return View(clientes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}