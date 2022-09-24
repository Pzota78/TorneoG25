using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Equipos
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioMunicipio _repoMunicipio;
        private readonly IRepositorioDT _repoDt;

        public Equipo equipo { get; set; }
        public IEnumerable<Municipio> municipio { get; set; }
        public IEnumerable<DirectorTecnico> dt { get; set; }

        public EditModel(IRepositorioEquipo repoEquipo, IRepositorioMunicipio repoMunicipio, IRepositorioDT repoDt)
        {
            _repoEquipo = repoEquipo;
            _repoMunicipio = repoMunicipio;
            _repoDt = repoDt;
        }
        public IActionResult OnGet(int id)
        {
            equipo = _repoEquipo.GetEquipo(id);
            municipio = _repoMunicipio.GetAllMunicipios();
            dt = _repoDt.GetAllDT();
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(Equipo equipo, int idMunicipio, int idDt)
        {
            _repoEquipo.UpdateEquipo(equipo, idMunicipio, idDt);
            return RedirectToPage("Index");
        }
    }
}
