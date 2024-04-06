using ADSProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers

{
    [Route("api/profesores/")]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesor profesor;

        public ProfesorController(IProfesor profesor)
        {
            this.profesor = profesor;
        }

        [HttpDelete("eliminarProfesor/{idProfesor}")]
        public ActionResult<string> eliminarProfesor(int idProfesor)
        {
            try
            {
                bool eliminado = this.profesor.EliminarProfesor(idProfesor);

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
