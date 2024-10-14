using System.Collections;

namespace Validacion_WEB.Datos
{
    public interface IRepositorioBachillerato
    {
        public Task<IEnumerable> ListaBachillerato();
    }
}
