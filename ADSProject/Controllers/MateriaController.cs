using ADSProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
    [Route("api/materias/")]
    public class MateriasController : ControllerBase
    {
        private readonly IMateria materia;

        public MateriasController(IMateria materia)
        {
            this.materia = materia;
        }

        [HttpDelete("eliminarMateria/{idMateria}")]
        public ActionResult<string> eliminarMateria(int idMateria)
        {
            try
            {
                bool eliminado = this.materia.EliminarMateria(idMateria);

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
