using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PARCIAL.Models; // Para acceder a la clase Remesas
using PARCIAL.Data;
using Microsoft.EntityFrameworkCore;   // Para acceder a ApplicationDbContext

namespace PARCIAL.Controllers
{
    public class RemesaController : Controller
    {
        private readonly ILogger<RemesaController> _logger;
        private readonly ApplicationDbContext _context;

        public RemesaController(ILogger<RemesaController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

     // GET: /Remesa/
[HttpGet("")]
public async Task<IActionResult> Index()
{
    var remesas = await _context.Remesas.ToListAsync(); // Accede correctamente a la lista de remesas
    return View(remesas); // Pasa la lista de remesas a la vista
}

// GET: /Remesa/Create
[HttpGet("Create")]
public IActionResult Create()
{
    return View();
}

// POST: /Remesa/Create
[HttpPost("Create")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(Remesas remesa)
{
    if (ModelState.IsValid)
    {
        // Calcula el monto final basado en la tasa de cambio
        remesa.montoFinal = remesa.montoEnvio * remesa.tasaCambio;

        _context.Add(remesa); // Agrega la nueva remesa a la base de datos
        await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos

        return RedirectToAction(nameof(Index)); // Redirige a la lista de remesas
    }

    return View(remesa); // Si hay algún error, devuelve el formulario con los datos ingresados
}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
