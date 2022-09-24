using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Dts
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioDT _repoDt;
        public DirectorTecnico dt { get; set; }

        public EditModel(IRepositorioDT repoDt)
        {
            _repoDt = repoDt;
        }
        public IActionResult OnGet(int id)
        {
            dt = _repoDt.GetDT(id);
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(DirectorTecnico dt)
        {
            _repoDt.UpdateDT(dt);
            return RedirectToPage("Index");
        }
    }
}
