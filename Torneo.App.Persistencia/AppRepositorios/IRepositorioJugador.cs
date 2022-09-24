using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioJugador
    {
        public Jugador AddJugador(Jugador jugador, int idPosicion, int idEquipo);
        public IEnumerable<Jugador> GetAllJugadores();
        public Jugador GetJugador(int idJugador);
        public Jugador UpdateJugador(Jugador jugador, int idPosicion, int idEquipo);
    }
}
