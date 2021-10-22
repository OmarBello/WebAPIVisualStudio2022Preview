using Microsoft.EntityFrameworkCore;
using WebAPITeamMate2._0.Entidades;

namespace WebAPITeamMate2._0
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RecomendacionesPendientes> recomendacionesPendientes { get; set; }
        public DbSet<RecomendacionesDetenidas> recomendacionesDetenidas { get; set; }
        public DbSet<RecomendacionesCerradas> recomendacionesCerradas { get; set; }
        public DbSet<RecomendacionesImplementadas> recomendacionesImplementadas { get; set; }
        public DbSet<Incidencias> IncidenciasVencerPorVencer { get; set; }
        public DbSet<IncidenciasDetalles> IncidenciaDetalle { get; set; }
        public DbSet<SeleccionPorCodigo> SeleccionPorCodigo { get; set; }
    }
}
