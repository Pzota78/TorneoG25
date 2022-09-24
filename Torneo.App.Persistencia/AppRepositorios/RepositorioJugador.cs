using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioJugador : IRepositorioJugador
    {
        private readonly DataContext _dataContext = new DataContext();

        public Jugador AddJugador(Jugador jugador, int idPosicion, int idEquipo)
        {
            var posicionEncontrado = _dataContext.Posiciones.Find(idPosicion);
            var equipoEncontrado = _dataContext.Equipos.Find(idEquipo);
            jugador.Posicion = posicionEncontrado;
            jugador.Equipo = equipoEncontrado;
            
            var jugadorInsertado = _dataContext.Jugadores.Add(jugador);
            _dataContext.SaveChanges();
            return jugadorInsertado.Entity;
        }
        public IEnumerable<Jugador> GetAllJugadores()
        {
            var jugadores = _dataContext.Jugadores
            .Include(e => e.Equipo)
            .Include(e => e.Posicion)
            .ToList();
            return jugadores;
        }

        public Jugador GetJugador(int idJugador)
        {
            var jugadorEncontrado = _dataContext.Jugadores
            .Where(e => e.Id == idJugador)
            .Include(e => e.Equipo)
            .Include(e => e.Posicion)
            .FirstOrDefault();
            return jugadorEncontrado;
        }
        public Jugador UpdateJugador(Jugador jugador, int idPosicion, int idEquipo)
        {
            var posicionEncontrado = _dataContext.Posiciones.Find(idPosicion);
            var equipoEncontrado = _dataContext.Equipos.Find(idEquipo);
            jugador.Posicion = posicionEncontrado;
            jugador.Equipo = equipoEncontrado;

            var jugadorEncontrado = _dataContext.Jugadores.Find(jugador.Id);
            if (jugadorEncontrado != null)
            {
                jugadorEncontrado.Nombre = jugador.Nombre;
                jugadorEncontrado.Posicion = posicionEncontrado;
                jugadorEncontrado.Equipo = equipoEncontrado;
                _dataContext.SaveChanges();
            }
            return jugadorEncontrado;
        }
    }
}