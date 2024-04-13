using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class Grupo
    {

        public int IdCarrera{  set; get; }
        [Required(ErrorMessage = "Este es un campo requerido")]

        public int IdMateria { set; get; }
        [Required(ErrorMessage = "Este es un campo requerido")]

        public int IdProfesor { set; get; }
        [Required(ErrorMessage = "Este es un campo requerido")]

        public int Ciclo { set; get; }
        [Required(ErrorMessage = "Este es un campo requerido")]

        public int Anio {  set; get; }
        [Required(ErrorMessage = "Este es un campo requerido")]

        public int IdGrupo { get; set; }
    }
}
