using Microsoft.EntityFrameworkCore;

namespace WebAPITeamMate2._0.Entidades
{
    [Keyless]
    public class Incidencias
    {
        public string projectcode { get; set; }
        public string Proyecto { get; set; }
        public string categoria { get; set; }
        public int Bajo { get; set; }
        public int medio { get; set; }
        public int moderado { get; set; }
        public int alto { get; set; }
        public string entidad { get; set; }
        public string Estatus { get; set; }
    }
}
