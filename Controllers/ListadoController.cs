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
            var clientes = await _context.Clientes.OrderBy(c => c.Id).ToListAsync();
            return View(clientes);
        }

        // Acción para mostrar la tabla de clientes con un filtro
        public IActionResult FiltroCliente(bool? estado)
        {
            var clientes = _context.Clientes.AsQueryable();

            if (estado.HasValue)
            {
                clientes = clientes.Where(c => c.Estado == estado.Value);
            }

            return View(clientes.ToList());
        }

        // Acción para mostrar la tabla de clientes con un cliente desactivado
        public async Task<IActionResult> DesactivarCliente(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.Estado = false; // Cambia el estado a desactivado
            cliente.FechaModificacion = DateTime.UtcNow; // Actualiza la fecha de modificación
            _context.Update(cliente);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(TablaClientes));
        }

        // Acción para mostrar el formulario de edición
        public async Task<IActionResult> EditarCliente(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }


        // Acción para procesar los cambios del cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Asegúrate de que FechaCreacion y FechaModificacion estén en UTC
                    cliente.FechaCreacion = DateTime.SpecifyKind(cliente.FechaCreacion, DateTimeKind.Utc);
                    cliente.FechaModificacion = DateTime.UtcNow; // Actualiza la fecha de modificación a UTC
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Clientes.Any(e => e.Id == cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("TablaClientes","Listado"); // Redirige a la lista de Clientes
            }
            return View(cliente);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}