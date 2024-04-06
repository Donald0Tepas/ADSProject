﻿using ADSProject.Interfaces;
using ADSProject.Models;
using ADSProject.Utils;
using Microsoft.AspNetCore.Mvc;
namespace ADSProject.Controllers
{
    [Route("api/Estudiantes/")]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudiante estudiante;
        public const string COD_EXITO = "000000";
        public const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public EstudianteController (IEstudiante estudiante)
        {
            this.estudiante = estudiante;
        }


        [HttpPost("agregarEstudiantes")]
        public ActionResult<string> AgregarEstudiante([FromBody] Estudiante estudiante)
        {
            try
            {
                // Verificar que todas las validaciones por atributo del modelo este correctas
                if (!ModelState.IsValid)
                {
                    // En caso de no cumplir con todas las validaciones se procede a retornar una respuesta erronea
                    return BadRequest(ModelState);
                }
                int contador = this.estudiante.AgregarEstudiante(estudiante);

                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro insertado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al insertar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("actualizarEstudiante/{idEstudiante}")]

        public ActionResult<string> ActualizarEstudiante(int idEstudiante, [FromBody] Estudiante estudiante)
        {
            try
            {
                // Verificar que todas las validaciones por atributo del modelo este correctas
                if (!ModelState.IsValid)
                {
                    // En caso de no cumplir con todas las validaciones se procede a retornar una respuesta erronea
                    return BadRequest(ModelState);
                }
                int contador = this.estudiante.ActualizarEstudiante(idEstudiante, estudiante);

                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro actualizado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al actualizar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }

                [HttpDelete("eliminarEstudiante/{idEstudiante}")]

                public ActionResult<string> EliminarEstudiante(int idEstudiante)
            {
                try
                {
                    bool eliminado = this.estudiante.EliminarEstudiante(idEstudiante);

                    if (eliminado)
                    {
                        pCodRespuesta = COD_EXITO;
                        pMensajeUsuario = "Registro eliminado con exito";
                        pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                    }
                    else
                    {
                        pCodRespuesta = COD_ERROR;
                        pMensajeUsuario = "Ocurrio un problema al eliminar el registro";
                        pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                    }
                    return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
                catch (Exception)
                {
                    throw;
                }
                }
                [HttpGet("obtenerEstudiantePorID/{idEstudiante}")]
                public ActionResult<Estudiante> ObtenerEstudiantePorID (int idEstudiante)
                {
                try
                {
                Estudiante estudiante = this.estudiante.ObtenerEstudiantePorID(idEstudiante);
                if (estudiante != null)
                {
                    return Ok(estudiante);
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
                [HttpGet("obtenerEstudiantes")]
               public ActionResult<List<Estudiante>> ObtenerEstudiantes()
               {
               try
               {
               List<Estudiante> lstEstudiante = this.estudiante.ObtenerTodosLosEstudiantes();

               return Ok(lstEstudiante);   
               }
               catch (Exception)  
               {
               throw;
               }
               }
    }      
}
    
