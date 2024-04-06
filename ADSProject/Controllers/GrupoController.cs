using ADSProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
    [Route("api/grupos/")]
    public class GrupoController : ControllerBase
    {
        private readonly IGrupo grupo;

        public GrupoController(IGrupo grupo)
        {
            this.grupo = grupo;
        }

        [HttpDelete("eliminarGrupo/{idGrupo}")]
        public ActionResult<string> eliminarGrupo(int idGrupo)
        {
            try
            {
                bool eliminado = this.grupo.EliminarGrupo(idGrupo);

                if (eliminado)
                {
                    return Ok(new { pCodRespuesta = "0000000" });
                }
                else
                {
                    return NotFound(new { pCodRespuesta = "999999" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
