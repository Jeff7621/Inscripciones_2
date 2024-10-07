using Validacion_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;

namespace Validacion_WEB.Datos
{
    public class RepositorioMatricula: IRepositorioMatricula
    {
        private readonly AplicationDBContext _context;
        
        public RepositorioMatricula(AplicationDBContext context)
        {
            _context = context;
        }

      
        public async Task<IEnumerable<MatriculaEstudiante>> ListaMatricula()
        {
            return await _context.Tmatricula.ToListAsync();
        }

        public async Task Crear(MatriculaEstudiante matricula)
        {
            _context.Tmatricula.Add(matricula);
            await _context.SaveChangesAsync();
        }
    }
}
