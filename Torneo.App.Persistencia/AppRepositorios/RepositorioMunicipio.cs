using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioMunicipio : IRepositorioMunicipio
    {
        private readonly DataContext dataContext = new DataContext();

        public Municipio AddMunicipio (Municipio municipio)
        {
            var municipioInsertado = dataContext.Municipios.Add (municipio);
            _dataContext SaveChanges();
            return municipioInsertado.Entity;
}
    }
}