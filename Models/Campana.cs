namespace RetailCam.Models
{
    public class Campana
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal DescuentoPct { get; set; }
        public string Canal { get; set; }
        public string Descripcion { get; set; }
    }
}