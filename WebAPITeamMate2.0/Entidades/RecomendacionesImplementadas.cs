using Microsoft.EntityFrameworkCore;

namespace WebAPITeamMate2._0.Entidades
{
    [Keyless]
    public class RecomendacionesImplementadas
    {
        //public int ID { get; set; }
        public string Codigo { get; set; }
        public string Proyecto { get; set; }
        public string Titulo { get; set; }
        public string Estado { get; set; }
        public string Categoria { get; set; }
        public string Responsable { get; set; }

        public string Riesgo { get; set; }
        public string Estatus { get; set; }
        public string Coordinador { get; set; }

        public string Entidad { get; set; }

        public string Fecha_Notificacion { get; set; }
        public int Dias_Transcurridos { get; set; }
        public string Fecha_Envio { get; set; }
    }
}
