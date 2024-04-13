using ADSProject.Interfaces;
using ADSProject.Models;
using ADSProject.Utils;
using Microsoft.AspNetCore.Mvc;
namespace ADSProject.Controllers
{
    [Route("api/Profesor/")]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesor profesor;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private String pCodRespuesta;
        private String pMensajeUsuario;
        private String pMensajeTecnico;

        public ProfesorController(IProfesor profesor)
        {
            this.profesor = profesor;
        }
        [HttpPost("AgregarProfesor")]
        public ActionResult<string> AgregarProfesor([FromBody] Profesor profesor)
        {
            try
            {
                // Verificar que todas las validaciones por atributo del modelo este correctas
                if (!ModelState.IsValid)
                {
                    // En caso de no cumplir con todas las validaciones se procede a retornar una respuesta erronea
                    return BadRequest(ModelState);
                }
                int contador = this.profesor.AgregarProfesor(profesor);
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

        [HttpPut("ActualizarProfesor/{IdProfesor}")]
        public ActionResult<string> ActualizarProfesor(int IdProfesor, [FromBody] Profesor profesor)
        {
            try
            {
                // Verificar que todas las validaciones por atributo del modelo este correctas
                if (!ModelState.IsValid)
                {
                    // En caso de no cumplir con todas las validaciones se procede a retornar una respuesta erronea
                    return BadRequest(ModelState);
                }
                int contador = this.profesor.ActualizarProfesor(IdProfesor, profesor);

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

        [HttpDelete("EliminarProfesor/{IdProfesor}")]
        public ActionResult<string> EliminarProfesor(int IdProfesor)
        {
            try
            {
                bool eliminado = this.profesor.EliminarProfesor(IdProfesor);
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

        [HttpGet("ObtenerProfesorPorID/{IdProfesor}")]
        public ActionResult<Profesor> ObtenerProfesorPorID(int IdProfesor)
        {
            try
            {
                Profesor profesor = this.profesor.ObtenerProfesorPorID(IdProfesor);
                if (profesor != null)
                {
                    return Ok(profesor);
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

        [HttpGet("obtenerProfesores")]
        public ActionResult<List<Profesor>> ObtenerProfesores()
        {
            try
            {
                List<Profesor> lstProfesor = this.profesor.ObtenerProfesores();
                return Ok(lstProfesor);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
