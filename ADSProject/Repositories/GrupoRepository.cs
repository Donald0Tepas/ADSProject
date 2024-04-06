using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class GrupoRepository : IGrupo
    {
        private List<Grupo> listitaGrupos = new List<Grupo>
        {
            new Grupo{IdGrupo = 1, IdCarrera = 1, IdMateria = 1, IdProfesor = 1, Ciclo = 01, Anio = 2024}
        };

        public int ActualizarGrupo(int idGrupo, Grupo grupo)
        {
            try
            {
                int bandera = 0;

                int index = listitaGrupos.FindIndex(tmp => tmp.IdGrupo == idGrupo);

                if (index >= 0)
                {
                    listitaGrupos[index] = grupo;
                    bandera = idGrupo;
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

        public int AgregarGrupo(Grupo grupo)
        {
            try
            {
                if (listitaGrupos.Count > 0)
                {
                    grupo.IdGrupo = listitaGrupos.Last().IdGrupo + 1;
                }
                listitaGrupos.Add(grupo);

                return grupo.IdGrupo;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool EliminarGrupo(int idGrupo)
        {
            try
            {
                bool bandera = false;
                int index = listitaGrupos.FindIndex(aux => aux.IdGrupo == idGrupo);

                if (index >= 0)
                {
                    listitaGrupos.RemoveAt(index);
                    bandera = true;
                }

                return bandera;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public Grupo ObtenerGrupoPorID(int idGrupo)
        {
            try
            {
                var grupo = listitaGrupos.FirstOrDefault(tmp => tmp.IdGrupo == idGrupo);

                return grupo;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Grupo> ObtenerGrupos()
        {
            try
            {
                return listitaGrupos;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
