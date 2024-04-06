using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class ProfesorRepository : IProfesor
    {
        private List<Profesor> listitaProfesor = new List<Profesor>
        {
            new Profesor{IdProfesor = 1, NombresProfesor = "Donaldo Alfredo", ApellidosProfesor = "Santos Tepas", Email = "alfredosantos2024@gmail.com"}
        };
        public int ActualizarProfesor(int idProfesor, Profesor profesor)
        {
            try
            {
                int bandera = 0;

                int index = listitaProfesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);

                if (index >= 0)
                {
                    listitaProfesor[index] = profesor;
                    bandera = idProfesor;
                }
                else
                {
                    bandera = -1;
                }

                return bandera;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int AgregarProfesor(Profesor profesor)
        {
            try
            {
                if (listitaProfesor.Count > 0)
                {
                    profesor.IdProfesor = listitaProfesor.Last().IdProfesor + 1;
                }
                listitaProfesor.Add(profesor);

                return profesor.IdProfesor;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool EliminarProfesor(int idProfesor)
        {
            try
            {
                bool bandera = false;
                int index = listitaProfesor.FindIndex(aux => aux.IdProfesor == idProfesor);

                if (index >= 0)
                {
                    listitaProfesor.RemoveAt(index);
                    bandera = true;
                }

                return bandera;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public Profesor ObtenerProfesorPorID(int idProfesor)
        {
            try
            {
                var profesor = listitaProfesor.FirstOrDefault(tmp => tmp.IdProfesor == idProfesor);

                return profesor;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Profesor> ObtenerProfesores()
        {
            try
            {
                return listitaProfesor;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

