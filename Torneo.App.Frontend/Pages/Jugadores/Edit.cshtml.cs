using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Jugadores
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioJugador _repoJugador;
        private readonly IRepositorioPosicion _repoPosicion;
        private readonly IRepositorioEquipo _repoEquipo;

        public Jugador jugador { get; set; }
        public IEnumerable<Equipo> equipo { get; set; }
        public IEnumerable<Posicion> posicion { get; set; }

        public EditModel(IRepositorioJugador jugador, IRepositorioEquipo repoEquipo, IRepositorioPosicion repoPosicion)
        {
            _repoJugador = jugador;
            _repoEquipo = repoEquipo;
            _repoPosicion = repoPosicion;
        }
        public IActionResult OnGet(int id)
        {
            jugador = _repoJugador.GetJugador(id);
            equipo = _repoEquipo.GetAllEquipos();
            posicion = _repoPosicion.GetAllPosicion();
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(Jugador jugador, int idPosicion, int idEquipo)
        {
            _repoJugador.UpdateJugador(jugador, idPosicion, idEquipo);
            return RedirectToPage("Index");
        }
    }
}
