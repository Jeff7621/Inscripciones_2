using System.Collections;
using Validacion_WEB.Models;
namespace Validacion_WEB.Datos;
using System.Linq;


public interface IRepositorioMatricula
{
    public Task<IEnumerable<MatriculaEstudiante>> ListaMatricula();

    public Task Crear(MatriculaEstudiante matricula);
}

