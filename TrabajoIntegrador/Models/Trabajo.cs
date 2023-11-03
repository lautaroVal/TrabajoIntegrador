using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoIntegrador.Models
{
    public class Trabajo
    {
        [Key]
        public int CodTrabajo { get; set; }
        public DateTime Fecha { get; set; }
        public int CodProyecto { get; set; }

        [ForeignKey("CodProyecto")]
        public Proyecto Proyecto { get; set; }
        public int CodServicio { get; set; }

        [ForeignKey("CodServicio")]
        public Servicio Servicio { get; set; }
        public int CantHoras { get; set; }
        public double ValorHora { get; set; }
        public double Costo { get; set; }
    }
}
