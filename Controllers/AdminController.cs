using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Validacion_WEB.Datos;
using System.Linq;

namespace Validacion_WEB.Controllers
{
    public class AdminController : Controller
    {
        private readonly AplicationDBContext _context;
        private readonly IRepositorioMatricula _repositorioMatricula;

        public AdminController(AplicationDBContext context, IRepositorioMatricula repositorioMatricula)
        {
            _context = context;
            _repositorioMatricula = repositorioMatricula;
        }

        public IActionResult Admin()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BachiGeneral()
        {
            // Filtra directamente por el bachillerato "General"
            var listaMatricula = await _repositorioMatricula.ListaMatricula();
            var matriculadosGeneral = listaMatricula
            .Where(m => m.OpcionBachillerato.Equals("General", StringComparison.OrdinalIgnoreCase))
            .ToList();

            return View(matriculadosGeneral);
        }

        [HttpGet]
        public async Task<IActionResult> BachiMecanica()
        {
            // Filtra directamente por el bachillerato "Mecánica"
            var listaMatricula = await _repositorioMatricula.ListaMatricula();
            var matriculadosMecanica = listaMatricula
            .Where(m => m.OpcionBachillerato.Equals("Mecanica", StringComparison.OrdinalIgnoreCase))
            .ToList();

            return View(matriculadosMecanica);
        }

        [HttpGet]
        public async Task<IActionResult> BachiSoftware()
        {
            // Filtra directamente por el bachillerato "Software"
            var listaMatricula = await _repositorioMatricula.ListaMatricula();
            var matriculadosMecanica = listaMatricula
            .Where(m => m.OpcionBachillerato.Equals("Desarrollo de software", StringComparison.OrdinalIgnoreCase))
            .ToList();

            return View(matriculadosMecanica);
        }


        [HttpGet]
        public async Task<IActionResult> BachiAsistencia()
        {
            // Filtra directamente por el bachillerato "Asistencia"
            var listaMatricula = await _repositorioMatricula.ListaMatricula();
            var matriculadosAsistencia = listaMatricula
            .Where(m => m.OpcionBachillerato.Equals("Administracion", StringComparison.OrdinalIgnoreCase))
            .ToList();

            return View(matriculadosAsistencia);
        }

        [HttpGet]
        public async Task<IActionResult> BachiContador()
        {
            // Filtra directamente por el bachillerato "Mecánica"
            var listaMatricula = await _repositorioMatricula.ListaMatricula();
            var matriculadosContador = listaMatricula
            .Where(m => m.OpcionBachillerato.Equals("Contaduria", StringComparison.OrdinalIgnoreCase))
            .ToList();

            return View(matriculadosContador);
        }

    }
}
