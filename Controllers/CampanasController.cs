using Microsoft.AspNetCore.Mvc;
using RetailCam.Models;

namespace RetailCam.Controllers
{
    public class CampanasController : Controller
    {
        // Lista estática en memoria simulando la base de datos
        private static List<Campana> _campanas = new List<Campana>
        {
            new Campana { Id = 1, Nombre = "CyberWow Electro", Categoria = "Electro", Estado = "Vigente", FechaInicio = new DateTime(2026, 3, 10), FechaFin = new DateTime(2026, 3, 15), DescuentoPct = 30, Canal = "Web", Descripcion = "Descuentos en tecnología y electrodomésticos." },
            new Campana { Id = 2, Nombre = "Renueva tu Hogar", Categoria = "Hogar", Estado = "Vigente", FechaInicio = new DateTime(2026, 3, 1), FechaFin = new DateTime(2026, 4, 1), DescuentoPct = 25, Canal = "Tienda", Descripcion = "Campaña especial para renovar tu hogar." },
            new Campana { Id = 3, Nombre = "Fashion Week Lima", Categoria = "Moda", Estado = "Próxima", FechaInicio = new DateTime(2026, 4, 10), FechaFin = new DateTime(2026, 4, 17), DescuentoPct = 40, Canal = "App", Descripcion = "La mejor moda de temporada." }
        };

        // RF: Listado - /Campanas
        public IActionResult Index(string categoria, string estado)
        {
            // Empezamos asumiendo que mostraremos todas las campañas
            var campanasFiltradas = _campanas.AsQueryable();

            // Si el usuario eligió una categoría (y no es "Todos"), filtramos
            if (!string.IsNullOrEmpty(categoria) && categoria != "Todos")
            {
                campanasFiltradas = campanasFiltradas.Where(c => c.Categoria == categoria);
            }

            // Si el usuario eligió un estado (y no es "Todos"), filtramos
            if (!string.IsNullOrEmpty(estado) && estado != "Todos")
            {
                campanasFiltradas = campanasFiltradas.Where(c => c.Estado == estado);
            }

            // Guardamos las selecciones en el ViewBag para que los menús desplegables 
            // no se borren después de hacer clic en buscar
            ViewBag.CategoriaSeleccionada = categoria;
            ViewBag.EstadoSeleccionado = estado;
            ViewBag.TotalEncontradas = campanasFiltradas.Count();

            // Enviamos la lista ya filtrada a la vista
            return View(campanasFiltradas.ToList());
        }
    }
}
