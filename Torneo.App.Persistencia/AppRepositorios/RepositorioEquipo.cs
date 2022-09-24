using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        private readonly DataContext _dataContext = new DataContext();

         public Equipo AddEquipo(Equipo equipo, int idMunicipio, int idDT)
        {
            var municipioEncontrado = _dataContext.Municipios.Find(idMunicipio);
            var DTEncontrado = _dataContext.DirectoresTecnicos.Find(idDT);
            equipo.Municipio = municipioEncontrado;
            equipo.DirectorTecnico = DTEncontrado;
            var equipoInsertado = _dataContext.Equipos.Add(equipo);
            _dataContext.SaveChanges();
            return equipoInsertado.Entity;
        }
        public IEnumerable<Equipo> GetAllEquipos()
        {
            var equipos = _dataContext.Equipos
            .Include(e => e.Municipio)
            .Include(e => e.DirectorTecnico)
            .ToList();
            return equipos;
        }

        public Equipo GetEquipo(int idEquipo)
        {
            var equipoEncontrado = _dataContext.Equipos
            .Where(e => e.Id == idEquipo)
            .Include(e => e.Municipio)
            .Include(e => e.DirectorTecnico)
            .FirstOrDefault();
            return equipoEncontrado;
        }

        public Equipo UpdateEquipo(Equipo equipo, int idMunicipio, int idDT)
        {
            var municipioEncontrado = _dataContext.Municipios.Find(idMunicipio);
            var dtEncontrado = _dataContext.DirectoresTecnicos.Find(idDT);
            equipo.Municipio = municipioEncontrado;
            equipo.DirectorTecnico = dtEncontrado;

            var equipoEncontrado = _dataContext.Equipos.Find(equipo.Id);
            if (equipoEncontrado != null)
            {
                equipoEncontrado.Nombre = equipo.Nombre;
                equipoEncontrado.Municipio = municipioEncontrado;
                equipoEncontrado.DirectorTecnico = dtEncontrado;
                _dataContext.SaveChanges();
            }
            return equipoEncontrado;
        }

    }
}