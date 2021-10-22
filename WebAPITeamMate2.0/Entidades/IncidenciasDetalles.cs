using Microsoft.EntityFrameworkCore;

namespace WebAPITeamMate2._0.Entidades
{
    [Keyless]
    public class IncidenciasDetalles
    {
        //public int RecommendationID { get; set; }
        public string projectcode { get; set; }
        public string Nombre_Proyecto { get; set; }
        public string categoria { get; set; }
        public string categoria2 { get; set; }
        public string Riesgo { get; set; }
        public string Titulo { get; set; }
        public string Responsable { get; set; }
        public string Fecha_Estimada { get; set; }

        public int Día_Atraso { get; set; }
        public string entidad { get; set; }
        public string status { get; set; }
    }
}
