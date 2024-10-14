using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Validacion_WEB.Datos
{
    public class RepositorioBachillerato: IRepositorioBachillerato
    {
        private readonly AplicationDBContext _context;

        public RepositorioBachillerato(AplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable> ListaBachillerato()
        {
            return await _context.TBachilleratos.ToListAsync();
        }


    }

  
}
