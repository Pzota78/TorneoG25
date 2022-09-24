using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Persistencia;
using Torneo.App.Dominio;

namespace Torneo.App.Frontend.Pages.DTs
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioDT _repoDT;
        public IEnumerable<DirectorTecnico> dts { get; set; }
        public bool ErrorEliminar { get; set; }

        public IndexModel(IRepositorioDT repoDT)
        {
            _repoDT = repoDT;
        }
        public void OnGet()
        {
            dts = _repoDT.GetAllDT();
            ErrorEliminar = false;
        }
        public IActionResult OnPostDelete(int id)
        {
            try
            {
                _repoDT.DeleteDT(id);
                dts = _repoDT.GetAllDT();
                return Page();
            }
            catch (Exception ex)
            {
                dts = _repoDT.GetAllDT();
                ErrorEliminar = true;
                return Page();
            }
        }
    }
}
