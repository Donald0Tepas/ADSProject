using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class EsudianteRepository : IEstudiante
    {
        private List<Estudiante> lstEstudiantes = new List<Estudiante>
     {
            new Estudiante { IdEstudiante = 1, NombresEstudiantes = "JUAN CARLOS",
            ApellidosEstudiantes = "PEREZ SOSA", CodigoEstudiante = "PS24I04002",
            CorreoEstudiante = "PS24I04002@usonsonate.eedu.sv"
            }
      };
       /* private readonly ApplicationDbContext applicationDbContext;

        public EsudianteRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }*/
        public int ActualizarEstudiante(int idEstudiante, Estudiante estudiante)
        {
            try
            {
                int indice = lstEstudiantes.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);
                lstEstudiantes[indice] = estudiante;
                
                /*var item = applicationDbContext.Estudiantes.SingleOrDefaul(x => x.Id == idEstudiante);*/
                return idEstudiante;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int AgregarEstudiante(Estudiante estudiante)
        {
            try
            {
                if (lstEstudiantes.Count > 0)
                {
                    estudiante.IdEstudiante = lstEstudiantes.Last().IdEstudiante + 1;
                }
                lstEstudiantes.Add(estudiante);
                return estudiante.IdEstudiante;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool EliminarEstudiante(int idEstudiante)
        {
            try
            {
                int indice = lstEstudiantes.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);

                lstEstudiantes.RemoveAt(indice);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Estudiante ObtenerEstudiantePorID(int idEstudiante)
        {
            try
            {
                Estudiante estudiante = lstEstudiantes.FirstOrDefault(tmp => tmp.IdEstudiante == idEstudiante);

                return estudiante;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Estudiante> ObtenerTodosLosEstudiantes()
        {
            try
            {
                return lstEstudiantes;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
