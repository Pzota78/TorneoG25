using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Jugadores
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioJugador _repoJugador;
        private readonly IRepositorioPosicion _repoPosicion;
        private readonly IRepositorioEquipo _repoEquipo;

        public Jugador jugador { get; set; }
        public IEnumerable<Equipo> equipo { get; set; }
        public IEnumerable<Posicion> posicion { get; set; }

        public CreateModel(IRepositorioJugador repoJugador, IRepositorioEquipo repoEquipo, IRepositorioPosicion repoPosicion)
        {
            _repoJugador = repoJugador;
            _repoEquipo = repoEquipo;
            _repoPosicion = repoPosicion;
        }
        public void OnGet()
        {
            jugador = new Jugador();
            equipo = _repoEquipo.GetAllEquipos();
            posicion = _repoPosicion.GetAllPosicion();
        }
        public IActionResult OnPost(Jugador jugador, int idPosicion, int idEquipo)
        {
            if (ModelState.IsValid)
            {
            _repoJugador.AddJugador(jugador, idPosicion, idEquipo);
            return RedirectToPage("Index");
            }
            else
            {
            {
                return RedirectToPage("Create");
            }
            }
        }
    }
}
