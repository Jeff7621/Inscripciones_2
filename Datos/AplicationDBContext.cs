using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Validacion_WEB.Models;

namespace Validacion_WEB.Datos
{
    public class AplicationDBContext : IdentityDbContext
    {
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options) : base(options)
        {


        }

        public DbSet<MatriculaEstudiante> Tmatricula { get; set; } 
    }
}
