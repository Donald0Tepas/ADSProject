using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
    [Route("api/grupos/")]
    public class GrupoController : ControllerBase
    {
        private readonly IGrupo grupo;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private String pCodRespuesta;
        private String pMensajeUsuario;
        private String pMensajeTecnico;

        public GrupoController (IGrupo grupo)
        {
            this.grupo = grupo;
        }
        [HttpPost("AgregarGrupo")]
        public ActionResult<string> AgregarGrupo([FromBody] Grupo grupo)
        {
            try
            {
                // Verificar que todas las validaciones por atributo del modelo este correctas
                if (!ModelState.IsValid)
                {
                    // En caso de no cumplir con todas las validaciones se procede a retornar una respuesta erronea
                    return BadRequest(ModelState);
                }
                int contador = this.grupo.AgregarGrupo(grupo);
                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro insertado con exito";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un porblema al inserta el registro";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("ActualizarGrupo/{IdGrupo}")]
        public ActionResult<string> ActualizarGrupo(int IdGrupo, [FromBody] Grupo grupo)
        {
            try
            {
                // Verificar que todas las validaciones por atributo del modelo este correctas
                if (!ModelState.IsValid)
                {
                    // En caso de no cumplir con todas las validaciones se procede a retornar una respuesta erronea
                    return BadRequest(ModelState);
                }
                int contador = this.grupo.ActualizarGrupo(IdGrupo, grupo);

                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Resgistro actualizado con exito";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;

                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un erro en el registro";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("EliminarGrupo/{IdGrupo}")]
        public ActionResult<string> EliminarGrupo(int IdGrupo)
        {
            try
            {
                bool eliminado = this.grupo.EliminarGrupo(IdGrupo);
                if (eliminado)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro elininado con exito";
                    pMensajeTecnico = pCodRespuesta + " ||" + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al eliminar el registro";
                    pMensajeTecnico = pCodRespuesta + "|| " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ObtenerGrupoPorId/{IdGrupo}")]
        public ActionResult<Carrera> ObtenerGrupoPorID(int IdGrupo)
        {
            try
            {
                Grupo grupo = this.grupo.ObtenerGrupoPorID(IdGrupo);
                if (grupo != null)
                {
                    return Ok(grupo);
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron datos del estudiante";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception)
            {
                throw;
            }


        }

        [HttpGet("obtenerGrupos")]
        public ActionResult<List<Grupo>> ObtenerGrupos()
        {
            try
            {
                List<Grupo> lstGrupo = this.grupo.ObtenerGrupos();
                return Ok(lstGrupo);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}