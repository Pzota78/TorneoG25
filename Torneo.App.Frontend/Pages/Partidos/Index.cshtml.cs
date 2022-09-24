using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Persistencia;
using Torneo.App.Dominio;

namespace Torneo.App.Frontend.Pages.Partidos
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        public IEnumerable<Partido> partidos{ get; set; }
        public bool ErrorEliminar { get; set; }

        public IndexModel(IRepositorioPartido repoPartido)
        {
            _repoPartido = repoPartido;
        }
        public void OnGet()
        {
            partidos = _repoPartido.GetAllPartidos();
            ErrorEliminar = false;
        }
        public IActionResult OnPostDelete(int id)
        {
            try
            {
                _repoPartido.DeletePartido(id);
                partidos = _repoPartido.GetAllPartidos();
                return Page();
            }
            catch (Exception ex)
            {
                partidos = _repoPartido.GetAllPartidos();
                ErrorEliminar = true;
                return Page();
            }
        }
    }
}
