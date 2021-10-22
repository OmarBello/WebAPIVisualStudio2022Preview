using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebAPITeamMate2._0.Entidades
{
    [Keyless]
    public class RecomendacionesPendientes
    {
        
        public int? Cantidad_Cambio { get; set; } 

        public int RecommendationID { get; set; }
        public string Codigo { get; set; }
        public string Proyecto { get; set; }
        public string Titulo { get; set; }
        public string Estado { get; set; }
        public string Fecha_Estimada { get; set; }
        public string Categoria { get; set; } 
        public string Riesgo { get; set; }
        public string Responsable { get; set; }
        public string Estatus { get; set; }
        public string? Coordinador { get; set; } 
        public string Entidad { get; set; }

        public int Día_atraso { get; set; }

        public string Fecha_Envio { get; set; }
        public string? Dominio { get; set; } 

    }
}
