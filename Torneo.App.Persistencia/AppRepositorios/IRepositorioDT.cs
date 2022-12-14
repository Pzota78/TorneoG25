using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioDT
    {
        public DirectorTecnico AddDT(DirectorTecnico directorTecnico);
        public IEnumerable<DirectorTecnico> GetAllDT();
        public DirectorTecnico GetDT(int idDT);
        public DirectorTecnico UpdateDT(DirectorTecnico dt);
    }
}