using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MostraClima.API.Data;
using MostraClima.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MostraClima.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("v1/[controller]")]
    public class ConsultasController : ControllerBase
    {
        /// <resumen>
        /// Consultar el historial de un usuario
        /// </summary>
        /// <param name = "userKey"> clave almacenada en el navegador del usuario </param>
        /// <código de respuesta = "200"> Lista de consultas </response>
        [HttpGet]
        public async Task<ActionResult<List<Consulta>>> ConsultarHistorico([FromServices] MostraClimaDbContext dbContext, [FromQuery] string userKey)
        {
            var consultas = await dbContext.Consultas.Where(c => c.UserKey == userKey).ToListAsync();
            return Ok(consultas);
        }

        /// <resumen>
        /// Devuelve el id de la última consulta realizada por el usuario
        /// </summary>
        /// <param name = "userKey"> clave almacenada en el navegador del usuario </param>
        /// <código de respuesta = "200"> ID de la última consulta </response>
        /// <response code = "204"> El usuario no ha realizado consultas, devuelve 0 </response>
        [HttpGet]
        [Route("ultimoId")]
        public async Task<ActionResult<int?>> ConsultarIdDeUltimoHistoricoDeUsuario([FromServices] MostraClimaDbContext dbContext, [FromQuery] string userKey)
        {
            var UltimaConsulta = await dbContext.Consultas.Where(c => c.UserKey == userKey).OrderBy(c => c.Id).LastOrDefaultAsync();
            int idUltimaConsulta;

            if (UltimaConsulta == null)
                idUltimaConsulta = 0;
            else
                idUltimaConsulta = UltimaConsulta.Id;

            return Ok(idUltimaConsulta);
        }

        /// <resumen>
        /// Consultar todos los historiales registrados en el banco
        /// </summary>
        /// <código de respuesta = "200"> Lista de consultas </response>
        [HttpGet]
        [Route("todas")]
        public async Task<ActionResult<List<Consulta>>> ConsultarTodosLosHistoricos([FromServices] MostraClimaDbContext dbContext)
        {
            var todasConsultas = await dbContext.Consultas.ToListAsync();
            return Ok(todasConsultas);
        }


       /// <resumen>
        /// Insertar el resultado de una consulta en la base de datos
        /// </summary>
        /// <param name = "query"> Consulta meteorológica realizada por el usuario </param>
        /// <returns> void </returns>
        /// <código de respuesta = "200"> consulta guardada correctamente </response>
        /// <response code = "400"> la consulta se envió fuera del patrón esperado </response>
        /// <código de respuesta = "500"> error al guardar la consulta </response>
        [HttpPost]
        public async Task<ActionResult> SalvarConsulta([FromServices] MostraClimaDbContext dbContext, [FromBody] Consulta consulta)
        {
            dbContext.Consultas.Add(consulta);
            await dbContext.SaveChangesAsync();
            return Ok("consulta salva com sucesso");
        }
    }
}
