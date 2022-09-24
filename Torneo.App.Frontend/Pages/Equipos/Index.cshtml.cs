using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Persistencia;
using Torneo.App.Dominio;

namespace Torneo.App.Frontend.Pages.Equipos
{
    public class IndexModel : PageModel
    {
    private readonly IRepositorioEquipo _repoEquipo;
    public IEnumerable<Equipo> equipos { get; set; }
    public bool ErrorEliminar { get; set; }

        public IndexModel(IRepositorioEquipo repoEquipo)
        {
            _repoEquipo = repoEquipo;
        }
        public void OnGet()
        {
            equipos = _repoEquipo.GetAllEquipos();
            ErrorEliminar = false;
        }
        public IActionResult OnPostDelete(int id)
        {
            try
            {
                _repoEquipo.DeleteEquipo(id);
                equipos = _repoEquipo.GetAllEquipos();
                return Page();
            }
            catch (Exception ex)
            {
                equipos = _repoEquipo.GetAllEquipos();
                ErrorEliminar = true;
                return Page();
            }
        }
    }
}
