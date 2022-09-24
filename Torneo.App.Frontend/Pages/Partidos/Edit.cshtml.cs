using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Torneo.App.Frontend.Pages.Partidos
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioEquipo _repoEquipoLocal;
        private readonly IRepositorioEquipo _repoEquipoVisitante;
        public IEnumerable<Equipo> equipoLocal { get; set; }
        public IEnumerable<Equipo> equipoVisitante { get; set; }

        public Partido partido { get; set; }
        
        public EditModel(IRepositorioPartido repoPartido, IRepositorioEquipo repoEquipoLocal, IRepositorioEquipo repoEquipoVisitante)
        {
            _repoPartido = repoPartido;
            _repoEquipoLocal = repoEquipoLocal;
            _repoEquipoVisitante = repoEquipoVisitante;
        }
        public IActionResult OnGet(int id)
        {
            partido = _repoPartido.GetPartido(id);
            equipoLocal = _repoEquipoLocal.GetAllEquipos();
            equipoVisitante = _repoEquipoVisitante.GetAllEquipos();
            
            if (id == null)
            {
                return NotFound();
            }
            else{
                return Page();
            }
            
        }
        public IActionResult OnPost(Partido partido, int idLocal, int idVisitante)
        {
            _repoPartido.UpdatePartido(partido, idLocal, idVisitante);
            return RedirectToPage("Index");
        }
    }
}
