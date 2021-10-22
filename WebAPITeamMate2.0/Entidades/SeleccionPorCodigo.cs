using Microsoft.EntityFrameworkCore;

namespace WebAPITeamMate2._0.Entidades
{
    [Keyless]
    public class SeleccionPorCodigo
    {
        public string projectcode { get; set; }
        public string Nombre_Proyecto { get; set; }
        public string Titulo { get; set; }
        public string estado { get; set; }
        public string Fecha_Estimada { get; set; }
        public string Categoria { get; set; }
        public string Riesgo { get; set; }
        public string Responsable { get; set; }
        public string status { get; set; }
        public string Coordinador { get; set; }
        public string entidad { get; set; }
        public int Día_atraso { get; set; }
        public string Fecha_Envio { get; set; }
        public string Dominio { get; set; }
    }
}
