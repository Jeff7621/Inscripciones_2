using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Validacion_WEB.Datos;
using Validacion_WEB.Models;


namespace Validacion_WEB.Controllers
{
    public class IndelController : Controller
    {
        private readonly AplicationDBContext _context;
        private readonly IRepositorioMatricula _repositorioMatricula;
        private readonly IRepositorioBachillerato _repositorioBachillerato;

        public IndelController(AplicationDBContext context, IRepositorioMatricula repositorioMatricula, IRepositorioBachillerato repositorioBachillerato)
        {
            _context = context;
            _repositorioMatricula = repositorioMatricula;
            _repositorioBachillerato = repositorioBachillerato;
        }

        [AllowAnonymous]
        public IActionResult Principal()
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult Mecanica()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Software()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult General()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Formulario()
        {
            ViewBag.lista = await _repositorioBachillerato.ListaBachillerato();
            return View();
        }

        [AllowAnonymous]
        public IActionResult Administrativa()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Contaduria()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Formulario(MatriculaEstudiante matricula)
        {
            if (ModelState.IsValid)
            {
                await _repositorioMatricula.Crear(matricula);
                return RedirectToAction("Principal", "Indel");

            }

            return View(matricula);



        }
    }
}
