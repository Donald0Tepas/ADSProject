using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    [PrimaryKey(nameof(IdGrupo))]
    public class Grupo
    {

        public int IdGrupo { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]

        public int IdCarrera{  set; get; }
        [Required(ErrorMessage = "Este es un campo requerido")]

        public int IdMateria { set; get; }
        [Required(ErrorMessage = "Este es un campo requerido")]

        public int IdProfesor { set; get; }
        [Required(ErrorMessage = "Este es un campo requerido")]

        public int Ciclo { set; get; }
        [Required(ErrorMessage = "Este es un campo requerido")]

        public int Anio {  set; get; }
    }
}
