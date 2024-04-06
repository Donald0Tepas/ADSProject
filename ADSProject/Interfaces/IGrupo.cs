using ADSProject.Models;

namespace ADSProject.Interfaces
{
    public interface IGrupo
    {
        public int AgregarGrupo(Grupo grupo);
        public int ActualizarGrupo(int idGrupo, Grupo grupo);

        public List<Grupo> ObtenerGrupos();

        public Grupo ObtenerGrupoPorID(int idGrupo);
        public bool EliminarGrupo(int idGrupo);
    }
}
