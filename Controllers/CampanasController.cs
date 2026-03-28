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
        public IActionResult Index()
        {
            return View(_campanas);
        }
    }
}
