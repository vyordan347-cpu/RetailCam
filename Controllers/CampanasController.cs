using Microsoft.AspNetCore.Mvc;
using RetailCam.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RetailCam.Controllers
{
    public class CampanasController : Controller
    {
        private static List<Campana> _campanas = new List<Campana>
        {
            new Campana { Id = 1, Nombre = "CyberWow Electro", Categoria = "Electro", Estado = "Vigente", FechaInicio = new DateTime(2026, 3, 10), FechaFin = new DateTime(2026, 3, 15), DescuentoPct = 30, Canal = "Web", Descripcion = "Descuentos en tecnología y electrodomésticos." },
            new Campana { Id = 2, Nombre = "Renueva tu Hogar", Categoria = "Hogar", Estado = "Vigente", FechaInicio = new DateTime(2026, 3, 1), FechaFin = new DateTime(2026, 4, 1), DescuentoPct = 25, Canal = "Tienda", Descripcion = "Campaña especial para renovar tu hogar con muebles y decoración a precios increíbles en todas nuestras tiendas." },
            new Campana { Id = 3, Nombre = "Fashion Week Lima", Categoria = "Moda", Estado = "Próxima", FechaInicio = new DateTime(2026, 4, 10), FechaFin = new DateTime(2026, 4, 17), DescuentoPct = 40, Canal = "App", Descripcion = "La mejor moda de temporada." }
        };

        // RF: Listado y Filtro - /Campanas
        public IActionResult Index(string categoria, string estado)
        {
            var campanasFiltradas = _campanas.AsQueryable();

            if (!string.IsNullOrEmpty(categoria) && categoria != "Todos")
            {
                campanasFiltradas = campanasFiltradas.Where(c => c.Categoria == categoria);
            }

            if (!string.IsNullOrEmpty(estado) && estado != "Todos")
            {
                campanasFiltradas = campanasFiltradas.Where(c => c.Estado == estado);
            }

            ViewBag.CategoriaSeleccionada = categoria;
            ViewBag.EstadoSeleccionado = estado;
            ViewBag.TotalEncontradas = campanasFiltradas.Count();

            return View(campanasFiltradas.ToList());
        }

        // RF: Detalle - /Campanas/Detalle/{id}
        public IActionResult Detalle(int id)
        {
            var campana = _campanas.FirstOrDefault(c => c.Id == id);
            if (campana == null) return NotFound();
            return View(campana);
        }

        // RF: Resumen - /Campanas/Resumen
        public IActionResult Resumen()
        {
            ViewBag.TotalCampanas = _campanas.Count;
            ViewBag.Vigentes = _campanas.Count(c => c.Estado == "Vigente");
            ViewBag.Proximas = _campanas.Count(c => c.Estado == "Próxima");
            ViewBag.PromedioDescuento = _campanas.Average(c => c.DescuentoPct);
            ViewBag.CanalWeb = _campanas.Count(c => c.Canal == "Web");
            ViewBag.CanalTienda = _campanas.Count(c => c.Canal == "Tienda");
            ViewBag.CanalApp = _campanas.Count(c => c.Canal == "App");

            return View();
        }
    }
}