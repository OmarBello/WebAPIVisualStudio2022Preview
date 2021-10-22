using WebAPITeamMate2._0.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPITeamMate2._0.Controllers
{
    [ApiController]
    [Route("api/recomendaciones")]
    public class RecomendacionesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public RecomendacionesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //Creacion de las APIS de los Store Procedure de TeamMate
        //Solo metodos GETS

        [HttpGet("Pendientes")]
        // api/Recomendaciones/Pendientes
        public async Task<IEnumerable<RecomendacionesPendientes>> Pendiente()
        {
            return await context.recomendacionesPendientes.FromSqlRaw("exec dbo.sp_Recomendaciones_Pendientes").ToListAsync();
        }

        [HttpGet("Detenidas")]
        // api/Recomendaciones/Detenidas
        public async Task<IEnumerable<RecomendacionesDetenidas>> Detenida()
        {
            return await context.recomendacionesDetenidas.FromSqlRaw("exec dbo.sp_Recomendacions_Detenidas").ToListAsync();
        }

        [HttpGet("Cerradas")]
        // api/Recomendaciones/Cerradas
        public async Task<IEnumerable<RecomendacionesCerradas>> Cerrada()
        {
            return await context.recomendacionesCerradas.FromSqlRaw("exec dbo.sp_Recomendaciones_Cerradas").ToListAsync();
        }

        [HttpGet("Implementadas")]
        // api/Recomendaciones/Implementadas
        public async Task<IEnumerable<RecomendacionesImplementadas>> Implementada()
        {
            return await context.recomendacionesImplementadas.FromSqlRaw("exec sp_Recomendaciones_Implementadas").ToListAsync();
        }


        [HttpGet("Incidencias")]
        // api/Recomendaciones/Incidencias
        public async Task<IEnumerable<Incidencias>> GetAllIncidenciaVencerPorVencer(string entidad, string estatus)
        {
            return  from data in await context.IncidenciasVencerPorVencer.FromSqlRaw("exec sp_GetAllIncidenciaVencerPorVencer").ToListAsync()
                         where data.entidad == entidad
                         && data.Estatus == estatus
                         select data;
        }

        [HttpGet("IncidenciasDetalle")]
        // api/Recomendaciones/IncidenciasDetalle
        public async Task<IEnumerable<IncidenciasDetalles>> IncidenciasDetalle(string entidad, string estatus)
        {
            return from data in await context.IncidenciaDetalle.FromSqlRaw("select projectcode,Nombre_Proyecto,IsNull(categoria, 'Debilidad de Control ( DC )') as categoria,IsNull(RIGHT(categoria, 6), '( DC )') as categoria2,Riesgo,Titulo,RESPONSABLE,convert(nvarchar, Fecha_estimada, 103) as Fecha_Estimada,Día_Atraso,entidad,status from [dbo].[Recomendaciones_01]order by projectcode").ToListAsync()
                   where data.entidad == entidad
                   && data.status == estatus
                   select data;
        }

        [HttpGet("GetAllProjectNivelriesgo")]
        // api/Recomendaciones/GetAllProjectNivelriesgo
        public async Task<IEnumerable<Incidencias>> GetAllProjectNivelriesgo(string projecto)
        {
            return from data in await context.IncidenciasVencerPorVencer.FromSqlRaw("select projectcode, Proyecto,IsNull(categoria, 'Debilidad de Control ( DC )') as categoria, sum(bajo) as Bajo,  sum(medio) as medio, sum(moderado) as moderado, sum(alto) as alto, entidad, 'Vencida' as Estatus from [dbo].[ov_resumen]  group by projectcode, Proyecto, categoria, entidad").ToListAsync()
                   where data.Proyecto == projecto
                   select data;
        }

        [HttpGet("GetAllProject")]
        // api/Recomendaciones/GetAllProject
        public async Task<IEnumerable<IncidenciasDetalles>> GetAllProject(string projecto)
        {
            return from data in await context.IncidenciaDetalle.FromSqlRaw("select projectcode,Nombre_Proyecto,IsNull(categoria, 'Debilidad de Control ( DC )') as categoria,IsNull(RIGHT(categoria, 6), '( DC )') as categoria2,Riesgo,Titulo,RESPONSABLE,convert(nvarchar, Fecha_estimada, 103) as Fecha_Estimada,Día_Atraso,entidad,status from [dbo].[Recomendaciones_01]order by projectcode").ToListAsync()
                   where data.Nombre_Proyecto == projecto
                   select data;
        }

        [HttpGet("SeleccionPorCodigo")]
        //GET api/Recomendaciones/SeleccionPorCodigo
        public async Task<IEnumerable<Incidencias>> SeleccionPorCodigo([FromQuery] string projectcode)
        {
            return from data in await context.IncidenciasVencerPorVencer.FromSqlRaw("exec sp_GetAllIncidenciaVencerPorVencer").ToListAsync()
                   where data.projectcode.Contains(projectcode)
                   select data;
        }

        [HttpGet("SeleccionPorCodigoAll")]
        //GET api/Recomendaciones/SeleccionPorCodigoAll
        public async Task<IEnumerable<SeleccionPorCodigo>> SeleccionPorCodigoAll([FromQuery] string projectcode)
        {
            return from data in await context.SeleccionPorCodigo.FromSqlRaw("select * from Recomendaciones_01").ToListAsync()
                   where data.projectcode.Contains(projectcode)
                   select data;
        }

        [HttpGet("SeleccionPorCodigoDoble")]
        //GET api/Recomendaciones/SeleccionPorCodigoDoble
        public async Task<IEnumerable<Incidencias>> SeleccionPorCodigoDoble([FromQuery] string projectcode, string projectcode2)
        {
            return from data in await context.IncidenciasVencerPorVencer.FromSqlRaw("exec sp_GetAllIncidenciaVencerPorVencer").ToListAsync()
                   where data.projectcode.Contains(projectcode) || data.projectcode.Contains(projectcode2)
                   select data;
        }

        [HttpGet("SeleccionPorCodigoDobleAll")]
        //GET api/Recomendaciones/SeleccionPorCodigoDobleAll
        public async Task<IEnumerable<SeleccionPorCodigo>> SeleccionPorCodigoDobleAll([FromQuery] string projectcode, string projectcode2)
        {
            return from data in await context.SeleccionPorCodigo.FromSqlRaw("select * from Recomendaciones_01").ToListAsync()
                   where data.projectcode.Contains(projectcode) || data.projectcode.Contains(projectcode2)
                   select data;
        }
    }
}
