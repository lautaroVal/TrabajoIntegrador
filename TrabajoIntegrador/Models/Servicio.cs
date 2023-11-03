using System.ComponentModel.DataAnnotations;

namespace TrabajoIntegrador.Models
{
    public class Servicio
    {
        [Key]
        public int CodServicio { get; set; }
        public string Descr { get; set; }
        public bool Estado { get; set;}
        public double ValorHora { get; set; }

    }
}
